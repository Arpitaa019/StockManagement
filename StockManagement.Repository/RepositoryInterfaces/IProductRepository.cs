using StockManagement.Entity;

namespace StockManagement.Interface
{
    public interface IProductRepository
    {
        Product? GetById(int id);
        IEnumerable<Product> GetAll();
        void Add(Product entity);
        void Update(Product entity);
        void Delete(int id);
    }

}
