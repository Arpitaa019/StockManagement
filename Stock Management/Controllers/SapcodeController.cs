using Microsoft.AspNetCore.Mvc;
using StockManagement.Core;
using StockManagement.Interface;

namespace Stock_Management.Controllers
{
    public class SapcodeController : Controller
    {
        private readonly ISapcodeService _service;
        public SapcodeController(ISapcodeService service) { _service = service; }

        // GET: Sapcode
        public ActionResult Index()
        {
            var list = _service.GetAll();
            return View(list);
        }

        // GET: Sapcode/Details/5
        public ActionResult Details(int id)
        {
            var item = _service.Get(id);
            if (item == null) return NotFound();
            return View(item);
        }

        // GET: Sapcode/Create
        public ActionResult Create()
        {
            return View(new Sapcode
            {
                IsActive       = true,
                AllocationDate = DateTime.Today,
                CreatedDate    = DateTime.Today,
                ModifiedDate   = DateTime.Today
            });
        }

        // POST: Sapcode/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sapcode sapcode)
        {
            if (!ModelState.IsValid) return View(sapcode);
            sapcode.CreatedDate  = DateTime.Now;
            sapcode.ModifiedDate = DateTime.Now;
            _service.Create(sapcode);
            return RedirectToAction(nameof(Index));
        }

        // GET: Sapcode/Edit/5
        public ActionResult Edit(int id)
        {
            var item = _service.Get(id);
            if (item == null) return NotFound();
            return View(item);
        }

        // POST: Sapcode/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Sapcode sapcode)
        {
            if (!ModelState.IsValid) return View(sapcode);
            sapcode.ItemCodeDescriptionMasterId =
                sapcode.ItemCodeDescriptionMasterId > 0 ? sapcode.ItemCodeDescriptionMasterId : id;
            sapcode.ModifiedDate = DateTime.Now;
            _service.Update(sapcode);
            return RedirectToAction(nameof(Index));
        }

        // GET: Sapcode/Delete/5
        public ActionResult Delete(int id)
        {
            var item = _service.Get(id);
            if (item == null) return NotFound();
            return View(item);
        }

        // POST: Sapcode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
