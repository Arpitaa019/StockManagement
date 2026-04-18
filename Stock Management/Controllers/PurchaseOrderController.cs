using Microsoft.AspNetCore.Mvc;
using StockManagement.Core;
using StockManagement.Interface;

namespace Stock_Management.Controllers
{
    public class PurchaseOrderController : Controller
    {
        private readonly IPurchaseOrderService _service;
        private readonly IPurchaseRequestService _prService;

        public PurchaseOrderController(IPurchaseOrderService service, IPurchaseRequestService prService)
        {
            _service = service;
            _prService = prService;
        }

        // GET: PurchaseOrder
        public ActionResult Index()
        {
            return View(_service.GetAll());
        }

        // GET: PurchaseOrder/Details/5
        public ActionResult Details(int id)
        {
            var po = _service.Get(id);
            if (po == null) return NotFound();
            return View(po);
        }

        // GET: PurchaseOrder/Create
        public ActionResult Create(int? prId)
        {
            var po = new PurchaseOrderMaster
            {
                OrderDate    = DateTime.Today,
                DeliveryDate = DateTime.Today.AddDays(30),
                CreatedDate  = DateTime.Today,
                ModifiedDate = DateTime.Today,
                Status       = "Draft",
                Items        = new List<PurchaseOrderDetails> { new PurchaseOrderDetails() }
            };

            // Pre-populate from Purchase Request if prId is provided
            if (prId.HasValue)
            {
                var pr = _prService.Get(prId.Value);
                if (pr != null)
                {
                    po.PRId      = pr.PRId;
                    po.PRNumber  = pr.PRNumber;
                    po.Department = pr.Department;
                    po.Items = pr.Items.Select(i => new PurchaseOrderDetails
                    {
                        ItemCodeNo    = i.ItemCodeNo,
                        Description   = i.Description,
                        Quantity      = i.Quantity,
                        UnitOfMeasure = i.UnitOfMeasure
                    }).ToList();
                    if (!po.Items.Any())
                        po.Items.Add(new PurchaseOrderDetails());
                }
            }

            ViewBag.PurchaseRequests = _prService.GetAll()
                .Select(p => new { p.PRId, p.PRNumber })
                .ToList();

            return View(po);
        }

        // POST: PurchaseOrder/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PurchaseOrderMaster po)
        {
            po.Items = po.Items?.Where(i => !string.IsNullOrWhiteSpace(i.ItemCodeNo)).ToList()
                       ?? new List<PurchaseOrderDetails>();

            if (!ModelState.IsValid)
            {
                ViewBag.PurchaseRequests = _prService.GetAll()
                    .Select(p => new { p.PRId, p.PRNumber })
                    .ToList();
                return View(po);
            }

            po.CreatedDate  = DateTime.Now;
            po.ModifiedDate = DateTime.Now;
            _service.Create(po);
            return RedirectToAction(nameof(Index));
        }

        // GET: PurchaseOrder/Edit/5
        public ActionResult Edit(int id)
        {
            var po = _service.Get(id);
            if (po == null) return NotFound();
            if (!po.Items.Any())
                po.Items.Add(new PurchaseOrderDetails());

            ViewBag.PurchaseRequests = _prService.GetAll()
                .Select(p => new { p.PRId, p.PRNumber })
                .ToList();

            return View(po);
        }

        // POST: PurchaseOrder/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PurchaseOrderMaster po)
        {
            po.Items = po.Items?.Where(i => !string.IsNullOrWhiteSpace(i.ItemCodeNo)).ToList()
                       ?? new List<PurchaseOrderDetails>();

            if (!ModelState.IsValid)
            {
                ViewBag.PurchaseRequests = _prService.GetAll()
                    .Select(p => new { p.PRId, p.PRNumber })
                    .ToList();
                return View(po);
            }

            po.POId         = po.POId > 0 ? po.POId : id;
            po.ModifiedDate = DateTime.Now;
            _service.Update(po);
            return RedirectToAction(nameof(Index));
        }

        // GET: PurchaseOrder/Delete/5
        public ActionResult Delete(int id)
        {
            var po = _service.Get(id);
            if (po == null) return NotFound();
            return View(po);
        }

        // POST: PurchaseOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
