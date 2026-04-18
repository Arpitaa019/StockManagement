using StockManagement.Entity;
using StockManagement.Interface;
using StockManagement.Services.Interfaces;

namespace StockManagement.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo) { _repo = repo; }
        public Product? Get(int id) => _repo.GetById(id);
        public IEnumerable<Product> GetAll() => _repo.GetAll();
        public void Create(Product entity)
        {
            if (entity.Quantity < 0)
                throw new Exception("Quantity cannot be negative.");
            _repo.Add(entity);
        }
        public void Update(Product entity)
        {
            if (entity.Price <= 0)
                throw new Exception("Price must be greater than zero.");
            _repo.Update(entity);
        }
        public void Delete(int id) => _repo.Delete(id);

        public Task CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
