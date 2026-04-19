using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StockManagement.Entity;
using StockManagement.Interface;
using StockManagement.Services.Interfaces;

// View model for approve summary
public class IMIRApproveItem
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

namespace Stock_Management.Controllers
{
    public class IMRCumulativeController : Controller
    {
        private readonly IIMIRCumulativeService _service;
        private readonly IDailyMaterialDetailService _detailService;
        private readonly IDailyMaterialInfoService _dmrService;

        public IMRCumulativeController(IIMIRCumulativeService service, IDailyMaterialDetailService detailService, IDailyMaterialInfoService dmrService)
        {
            _service = service;
            _detailService = detailService;
            _dmrService = dmrService;
        }

        // GET: IMRCumulative
        public IActionResult Index()
        {
            var list = _service.GetAll();
            return View(list);
        }

        // GET: IMRCumulative/Details/5
        public IActionResult Details(int id)
        {
            var item = _service.Get(id);
            if (item == null) return NotFound();
            return View(item);
        }

        // GET: IMRCumulative/ApproveFromDmr/5
        public IActionResult ApproveFromDmr(int dmrId)
        {
            var details = _detailService.GetByDmrId(dmrId);
            if (details == null || !details.Any()) return RedirectToAction("Details", "DMR", new { id = dmrId });

            var summary = details.GroupBy(d => d.ProductId)
                .Select(g => new IMIRApproveItem { ProductId = g.Key, Quantity = g.Sum(x => x.Quantity) })
                .ToList();

            ViewBag.DmrId = dmrId;
            return View(summary);
        }

        // POST: IMRCumulative/ApproveFromDmr
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ApproveFromDmrConfirm(int dmrId)
        {
            var details = _detailService.GetByDmrId(dmrId);
            if (details == null || !details.Any()) return RedirectToAction("Details", "DMR", new { id = dmrId });

            var summary = details.GroupBy(d => d.ProductId)
                .Select(g => new { ProductId = g.Key, Quantity = g.Sum(x => x.Quantity) })
                .ToList();

            foreach (var s in summary)
            {
                var cum = new IMIRCumulative { ImirId = dmrId, Quantity = s.Quantity, Remarks = $"From DMR {dmrId}", CreatedDate = DateTime.Now };
                _service.Create(cum);
            }

            // mark DMR as finalized
            var master = _dmrService.Get(dmrId);
            if (master != null)
            {
                master.IsFinalized = true;
                master.FinalizedDate = DateTime.Now;
                _dmrService.Update(master);
            }

            return RedirectToAction("Index");
        }

        // GET: IMRCumulative/Create
        public IActionResult Create(int? imrId)
        {
            var model = new IMIRCumulative { CreatedDate = DateTime.Now };
            if (imrId.HasValue) model.ImirId = imrId.Value;

            var imrList = _service.GetAll().Select(i => new SelectListItem($"IMIR-{i.ImirId}", i.ImirId.ToString())).ToList();
            ViewBag.ImrList = imrList;
            return View(model);
        }

        // POST: IMRCumulative/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IMIRCumulative model)
        {
            if (!ModelState.IsValid)
            {
                var imrList = _service.GetAll().Select(i => new SelectListItem($"IMIR-{i.ImirId}", i.ImirId.ToString())).ToList();
                ViewBag.ImrList = imrList;
                return View(model);
            }

            _service.Create(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: IMRCumulative/Edit/5
        public IActionResult Edit(int id)
        {
            var model = _service.Get(id);
            if (model == null) return NotFound();
            var imrList = _service.GetAll().Select(i => new SelectListItem($"IMIR-{i.ImirId}", i.ImirId.ToString())).ToList();
            ViewBag.ImrList = imrList;
            return View(model);
        }

        // POST: IMRCumulative/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IMIRCumulative model)
        {
            if (id != model.ImirCumulativeId) return BadRequest();
            if (!ModelState.IsValid)
            {
                var imrList = _service.GetAll().Select(i => new SelectListItem($"IMIR-{i.ImirId}", i.ImirId.ToString())).ToList();
                ViewBag.ImrList = imrList;
                return View(model);
            }

            _service.Update(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: IMRCumulative/Delete/5
        public IActionResult Delete(int id)
        {
            var model = _service.Get(id);
            if (model == null) return NotFound();
            return View(model);
        }

        // POST: IMRCumulative/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
