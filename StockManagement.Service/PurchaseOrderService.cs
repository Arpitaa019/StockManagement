using StockManagement.Core;
using StockManagement.Interface;

namespace StockManagement.Service
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _repo;
        public PurchaseOrderService(IPurchaseOrderRepository repo) { _repo = repo; }
        public PurchaseOrderMaster? Get(int id) => _repo.GetById(id);
        public IEnumerable<PurchaseOrderMaster> GetAll() => _repo.GetAll();
        public void Create(PurchaseOrderMaster entity) => _repo.Add(entity);
        public void Update(PurchaseOrderMaster entity) => _repo.Update(entity);
        public void Delete(int id) => _repo.Delete(id);
    }
}
