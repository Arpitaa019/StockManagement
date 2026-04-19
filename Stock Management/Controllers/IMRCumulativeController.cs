using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StockManagement.Entity;
using StockManagement.Interface;

namespace Stock_Management.Controllers
{
    public class IMRCumulativeController : Controller
    {
        private readonly IIMIRCumulativeService _service;

        public IMRCumulativeController(IIMIRCumulativeService service)
        {
            _service = service;
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
