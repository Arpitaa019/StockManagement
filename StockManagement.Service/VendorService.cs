using StockManagement.Core;
using StockManagement.Interface;

namespace StockManagement.Service
{
    public class VendorService : IVendorService
    {
        private readonly IVendorRepository _repo;
        public VendorService(IVendorRepository repo) { _repo = repo; }
        public Vendor? Get(int id) => _repo.GetById(id);
        public IEnumerable<Vendor> GetAll() => _repo.GetAll();
        public void Create(Vendor entity) => _repo.Add(entity);
        public void Update(Vendor entity) => _repo.Update(entity);
        public void Delete(int id) => _repo.Delete(id);
    }
}
