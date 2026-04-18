using Microsoft.AspNetCore.Mvc;
using StockManagement.Core;
using StockManagement.Interface;

namespace Stock_Management.Controllers
{
    public class PurchaseRequestController : Controller
    {
        private readonly IPurchaseRequestService _service;
        public PurchaseRequestController(IPurchaseRequestService service) { _service = service; }

        // GET: PurchaseRequest
        public ActionResult Index()
        {
            return View(_service.GetAll());
        }

        // GET: PurchaseRequest/Details/5
        public ActionResult Details(int id)
        {
            var pr = _service.Get(id);
            if (pr == null) return NotFound();
            return View(pr);
        }

        // GET: PurchaseRequest/Create
        public ActionResult Create()
        {
            return View(new PurchaseRequestMaster
            {
                RequestDate  = DateTime.Today,
                CreatedDate  = DateTime.Today,
                ModifiedDate = DateTime.Today,
                Status       = "Pending",
                Items        = new List<PurchaseRequestDetails> { new PurchaseRequestDetails() }
            });
        }

        // POST: PurchaseRequest/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PurchaseRequestMaster pr)
        {
            pr.Items = pr.Items?.Where(i => !string.IsNullOrWhiteSpace(i.ItemCodeNo)).ToList()
                       ?? new List<PurchaseRequestDetails>();

            if (!ModelState.IsValid) return View(pr);

            pr.CreatedDate  = DateTime.Now;
            pr.ModifiedDate = DateTime.Now;
            _service.Create(pr);
            return RedirectToAction(nameof(Index));
        }

        // GET: PurchaseRequest/Edit/5
        public ActionResult Edit(int id)
        {
            var pr = _service.Get(id);
            if (pr == null) return NotFound();
            if (!pr.Items.Any())
                pr.Items.Add(new PurchaseRequestDetails());
            return View(pr);
        }

        // POST: PurchaseRequest/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PurchaseRequestMaster pr)
        {
            pr.Items = pr.Items?.Where(i => !string.IsNullOrWhiteSpace(i.ItemCodeNo)).ToList()
                       ?? new List<PurchaseRequestDetails>();

            if (!ModelState.IsValid) return View(pr);

            pr.PRId          = pr.PRId > 0 ? pr.PRId : id;
            pr.ModifiedDate  = DateTime.Now;
            _service.Update(pr);
            return RedirectToAction(nameof(Index));
        }

        // GET: PurchaseRequest/Delete/5
        public ActionResult Delete(int id)
        {
            var pr = _service.Get(id);
            if (pr == null) return NotFound();
            return View(pr);
        }

        // POST: PurchaseRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
