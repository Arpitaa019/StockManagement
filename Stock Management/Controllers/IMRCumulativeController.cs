using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StockManagement.Entity;
using StockManagement.Interface;

namespace Stock_Management.Controllers
{
    public class IMRCumulativeController : Controller
    {
        private readonly IIMRCumulativeService _service;
        private readonly IIMRInfoService _imrService;

        public IMRCumulativeController(IIMRCumulativeService service, IIMRInfoService imrService)
        {
            _service = service;
            _imrService = imrService;
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

        // GET: IMRCumulative/Create
        public IActionResult Create(int? imrId)
        {
            var model = new IMRCumulative { CreatedDate = DateTime.Now };
            if (imrId.HasValue) model.ImrId = imrId.Value;

            var imrList = _imrService.GetAll().Select(i => new SelectListItem($"IMR-{i.ImrId} - Prod:{i.ProductId}", i.ImrId.ToString())).ToList();
            ViewBag.ImrList = imrList;
            return View(model);
        }

        // POST: IMRCumulative/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IMRCumulative model)
        {
            if (!ModelState.IsValid)
            {
                var imrList = _imrService.GetAll().Select(i => new SelectListItem($"IMR-{i.ImrId} - Prod:{i.ProductId}", i.ImrId.ToString())).ToList();
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
            var imrList = _imrService.GetAll().Select(i => new SelectListItem($"IMR-{i.ImrId} - Prod:{i.ProductId}", i.ImrId.ToString())).ToList();
            ViewBag.ImrList = imrList;
            return View(model);
        }

        // POST: IMRCumulative/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IMRCumulative model)
        {
            if (id != model.ImrCumulativeId) return BadRequest();
            if (!ModelState.IsValid)
            {
                var imrList = _imrService.GetAll().Select(i => new SelectListItem($"IMR-{i.ImrId} - Prod:{i.ProductId}", i.ImrId.ToString())).ToList();
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
