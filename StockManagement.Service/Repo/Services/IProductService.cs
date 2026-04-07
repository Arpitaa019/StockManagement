using StockManagement.Entity;

namespace StockManagement.Service.Repo.Services
{
    public interface IProductService
    {
        Task CreateProduct(Product product);
        Task DeleteProduct(int id);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task UpdateProduct(Product product);
    }
}
