using Microsoft.Data.SqlClient;
using StockManagement.Entity;
using StockManagement.Entity.DataHelper;
using StockManagement.Infrastructure.Repo.Abstraction;
using System;
using System.Data;

namespace StockManagement.Infrastructure.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbHelper _db;
        public ProductRepository(DbHelper db)
        {
            _db = db;
        }

        public async Task Create(Product product)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@ProductName", product.ProductName),
                new SqlParameter("@Price",product.Price),
                new SqlParameter("@Quantity",product.Quantity)
            };
            await _db.ExecuteNonQueryAsync("sp_InsertProduct", parameters);
        }

        public async Task Delete(int id)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@ProductId", id)
            };

            await _db.ExecuteNonQueryAsync("sp_DeleteProduct", parameters);
        }

        public async Task<Product> GetById(int id)
        {
            var parameters = new SqlParameter[]
             {
                new SqlParameter("@ProductId", id)
             };

            DataTable dt = await _db.ExecuteDataTableAsync("sp_GetProductById", parameters);

            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];
            return new Product
            {
                ProductId = (int)row["ProductId"],
                ProductName = row["ProductName"].ToString(),
                Price = (int)row["Price"],
                Quantity = (int)row["Quantity"]
            };
        }

        public async Task<IEnumerable<Product>> GetProduct()
        {
            DataTable dt = await _db.ExecuteDataTableAsync("sp_GetAllProducts");
            var products = new List<Product>();

            foreach (DataRow row in dt.Rows)
            {
                products.Add(new Product
                {
                    ProductId = (int)row["ProductId"],
                    ProductName = row["ProductName"].ToString(),
                    Price = (int)row["Price"],
                    Quantity = (int)row["Quantity"]
                });
            }

            return products;
        }

        public async Task Update(Product product)
        {
            var parameters = new SqlParameter[]
             {
                new SqlParameter("@ProductId", product.ProductId),
                new SqlParameter("@ProductName", product.ProductName),
                new SqlParameter("@Price", product.Price),
                new SqlParameter("@Quantity", product.Quantity)
             };
            await _db.ExecuteNonQueryAsync("sp_UpdateProduct", parameters);
        }
    }
}
