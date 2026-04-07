using StockManagement.Entity;
using StockManagement.Interface;

namespace StockManagement.Service
{
    public class InvoiceInfoService : IInvoiceInfoService
    {
        private readonly IInvoiceInfoRepository _repo;
        public InvoiceInfoService(IInvoiceInfoRepository repo) { _repo = repo; }
        public InvoiceInfo? Get(int id) => _repo.GetById(id);
        public IEnumerable<InvoiceInfo> GetAll() => _repo.GetAll();
        public void Create(InvoiceInfo entity) => _repo.Add(entity);
        public void Update(InvoiceInfo entity) => _repo.Update(entity);
        public void Delete(int id) => _repo.Delete(id);
    }
}