using Microsoft.AspNetCore.Mvc;
using StockManagement.Core;
using StockManagement.Interface;

namespace Stock_Management.Controllers
{
    public class VendorsController : Controller
    {
        private readonly IVendorService _service;
        public VendorsController(IVendorService service) { _service = service; }

        // GET: Vendors
        public ActionResult Index()
        {
            var vendors = _service.GetAll();
            return View(vendors);
        }

        // GET: Vendors/Details/5
        public ActionResult Details(int id)
        {
            var vendor = _service.Get(id);
            if (vendor == null) return NotFound();
            return View(vendor);
        }

        // GET: Vendors/Create
        public ActionResult Create()
        {
            return View(new Vendor { CreatedDate = DateTime.Today, IsActive = true });
        }

        // POST: Vendors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vendor vendor)
        {
            if (!ModelState.IsValid) return View(vendor);
            vendor.CreatedDate = DateTime.Now;
            _service.Create(vendor);
            return RedirectToAction(nameof(Index));
        }

        // GET: Vendors/Edit/5
        public ActionResult Edit(int id)
        {
            var vendor = _service.Get(id);
            if (vendor == null) return NotFound();
            return View(vendor);
        }

        // POST: Vendors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Vendor vendor)
        {
            if (!ModelState.IsValid) return View(vendor);
            vendor.VendorId = vendor.VendorId > 0 ? vendor.VendorId : id;
            vendor.ModifiedDate = DateTime.Now;
            _service.Update(vendor);
            return RedirectToAction(nameof(Index));
        }

        // GET: Vendors/Delete/5
        public ActionResult Delete(int id)
        {
            var vendor = _service.Get(id);
            if (vendor == null) return NotFound();
            return View(vendor);
        }

        // POST: Vendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
