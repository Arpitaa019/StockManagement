using StockManagement.Core;
using StockManagement.Interface;

namespace StockManagement.Service
{
    public class PurchaseRequestService : IPurchaseRequestService
    {
        private readonly IPurchaseRequestRepository _repo;
        public PurchaseRequestService(IPurchaseRequestRepository repo) { _repo = repo; }
        public PurchaseRequestMaster? Get(int id) => _repo.GetById(id);
        public IEnumerable<PurchaseRequestMaster> GetAll() => _repo.GetAll();
        public void Create(PurchaseRequestMaster entity) => _repo.Add(entity);
        public void Update(PurchaseRequestMaster entity) => _repo.Update(entity);
        public void Delete(int id) => _repo.Delete(id);
    }
}
