using Microsoft.AspNetCore.Mvc;
using StockManagement.Entity;
using StockManagement.Interface;

namespace Stock_Management.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceInfoService _service;
        private readonly IDailyMaterialInfoService _dmrService;
        private readonly IVendorService _vendorService;

        public InvoiceController(IInvoiceInfoService service, IDailyMaterialInfoService dmrService, IVendorService vendorService)
        {
            _service = service;
            _dmrService = dmrService;
            _vendorService = vendorService;
        }

        // GET: Invoice
        public ActionResult Index()
        {
            return View(_service.GetAll());
        }

        // GET: Invoice/Details/5
        public ActionResult Details(int id)
        {
            var invoice = _service.Get(id);
            if (invoice == null) return NotFound();
            LoadDropdowns();
            return View(invoice);
        }

        // GET: Invoice/Create
        public ActionResult Create(int? dmrId)
        {
            var invoice = new InvoiceMaster
            {
                InvoiceDate = DateTime.Today,
                Status      = "Pending"
            };

            if (dmrId.HasValue)
            {
                var dmr = _dmrService.Get(dmrId.Value);
                if (dmr != null)
                {
                    invoice.DmrId    = dmr.DmrId;
                    invoice.VendorId = dmr.VendorId;
                }
            }

            LoadDropdowns();
            return View(invoice);
        }

        // POST: Invoice/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InvoiceMaster invoice)
        {
            if (!ModelState.IsValid)
            {
                LoadDropdowns();
                return View(invoice);
            }
            _service.Create(invoice);
            return RedirectToAction(nameof(Index));
        }

        // GET: Invoice/Edit/5
        public ActionResult Edit(int id)
        {
            var invoice = _service.Get(id);
            if (invoice == null) return NotFound();
            LoadDropdowns();
            return View(invoice);
        }

        // POST: Invoice/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, InvoiceMaster invoice)
        {
            if (!ModelState.IsValid)
            {
                LoadDropdowns();
                return View(invoice);
            }
            invoice.InvoiceId = invoice.InvoiceId > 0 ? invoice.InvoiceId : id;
            _service.Update(invoice);
            return RedirectToAction(nameof(Index));
        }

        // GET: Invoice/Delete/5
        public ActionResult Delete(int id)
        {
            var invoice = _service.Get(id);
            if (invoice == null) return NotFound();
            LoadDropdowns();
            return View(invoice);
        }

        // POST: Invoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private void LoadDropdowns()
        {
            ViewBag.DmrList     = _dmrService.GetAll().ToList();
            ViewBag.VendorList  = _vendorService.GetAll().ToList();
        }
    }
}
