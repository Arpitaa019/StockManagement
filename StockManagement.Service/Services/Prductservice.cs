using StockManagement.Entity;
using StockManagement.Infrastructure.Repo.Abstraction;
using StockManagement.Service.Repo.Services;
using System;

namespace StockManagement.Service.Services
{
    /// <summary>
    /// Implements business logic for Product management.
    /// Uses repository for DB operations.
    /// </summary>

    public class ProductService : IProductService
    {
        private readonly IProductRepository _product;
        public ProductService(IProductRepository product)
        {
            _product = product;
        }
        public async Task CreateProduct(Product product)
        {
            if (product.Quantity < 0)
                throw new System.Exception("Quantity cannot be negative.");

            await _product.Create(product);
        }

        public async Task DeleteProduct(int id)
        {
            await _product.Delete(id);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
              return await _product.GetProduct();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _product.GetById(id);
        }

        public async Task UpdateProduct(Product product)
        {
            // Business rule example: price must be > 0
            if (product.Price <= 0)
                throw new System.Exception("Price must be greater than zero.");

            await _product.Update(product);
        }
    }
}
