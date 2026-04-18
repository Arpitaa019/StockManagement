using StockManagement.Entity;
using StockManagement.Interface;

namespace StockManagement.Service
{
    public class InvoiceInfoService : IInvoiceInfoService
    {
        private readonly IInvoiceInfoRepository _repo;
        public InvoiceInfoService(IInvoiceInfoRepository repo) { _repo = repo; }
        public InvoiceMaster? Get(int id) => _repo.GetById(id);
        public IEnumerable<InvoiceMaster> GetAll() => _repo.GetAll();
        public void Create(InvoiceMaster entity) => _repo.Add(entity);
        public void Update(InvoiceMaster entity) => _repo.Update(entity);
        public void Delete(int id) => _repo.Delete(id);
    }
}