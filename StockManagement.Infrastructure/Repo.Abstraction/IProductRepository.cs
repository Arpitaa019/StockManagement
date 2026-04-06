using StockManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;


namespace StockManagement.Infrastructure.Repo.Abstraction
{
    public interface IProductRepository
    {
        Task Create(Product product);
        Task<IEnumerable<Product>> GetProduct();
        Task<Product> GetById(int id);
        Task Update(Product product);
        Task Delete(int id);
    }
}
