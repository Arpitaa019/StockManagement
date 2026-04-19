using Microsoft.AspNetCore.Mvc;
using StockManagement.Entity;
using StockManagement.Interface;
using StockManagement.Services.Interfaces;

namespace Stock_Management.Controllers
{
    public class DMRController : Controller
    {
        private readonly IDailyMaterialInfoService _service;
        private readonly IDailyMaterialDetailService _detailService;

        public DMRController(IDailyMaterialInfoService service, IDailyMaterialDetailService detailService)
        {
            _service = service;
            _detailService = detailService;
        }

        // GET: DMR
        public IActionResult Index()
        {
            var list = _service.GetAll();
            return View(list);
        }

        // GET: DMR/Details/5
        public IActionResult Details(int id)
        {
            var model = _service.Get(id);
            if (model == null) return NotFound();
            var details = _detailService.GetByDmrId(id);
            ViewBag.Details = details;
            return View(model);
        }

        // GET: DMR/Create
        public IActionResult Create()
        {
            var model = new DMRMaster { DeliveryDate = DateTime.Now };
            return View(model);
        }

        // POST: DMR/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DMRMaster model)
        {
            if (!ModelState.IsValid) return View(model);
            _service.Create(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: DMR/Edit/5
        public IActionResult Edit(int id)
        {
            var model = _service.Get(id);
            if (model == null) return NotFound();
            return View(model);
        }

        // POST: DMR/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, DMRMaster model)
        {
            if (id != model.DmrId) return BadRequest();
            if (!ModelState.IsValid) return View(model);
            _service.Update(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: DMR/Delete/5
        public IActionResult Delete(int id)
        {
            var model = _service.Get(id);
            if (model == null) return NotFound();
            return View(model);
        }

        // POST: DMR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        // Helper to manage details (simple endpoints)
        // POST: DMR/AddDetail
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDetail(DmrDetails detail)
        {
            if (!ModelState.IsValid) return RedirectToAction(nameof(Details), new { id = detail.DmrId });
            _detailService.Create(detail);
            return RedirectToAction(nameof(Details), new { id = detail.DmrId });
        }

        // POST: DMR/RemoveDetail
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveDetail(int id, int dmrId)
        {
            _detailService.Delete(id);
            return RedirectToAction(nameof(Details), new { id = dmrId });
        }
    }
}
