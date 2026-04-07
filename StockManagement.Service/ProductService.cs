using StockManagement.Entity;
using StockManagement.Interface;

namespace StockManagement.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo) { _repo = repo; }
        public Product? Get(int id) => _repo.GetById(id);
        public IEnumerable<Product> GetAll() => _repo.GetAll();
        public void Create(Product entity) => _repo.Add(entity);
        public void Update(Product entity) => _repo.Update(entity);
        public void Delete(int id) => _repo.Delete(id);
    }
}