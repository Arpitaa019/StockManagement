using System.Data;
using System.Data.SqlClient;
using StockManagement.Entity;
using StockManagement.Interface;

namespace StockManagement.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;
        public ProductRepository(string connectionString) { _connectionString = connectionString; }

        public Product? GetById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetProductById", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@ProductId", id);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                return new Product { ProductId = (int)reader["ProductId"], ProductName = reader["ProductName"].ToString()!, Price = (int)reader["Price"], Quantity = (int)reader["Quantity"] };
            return null;
        }

        public IEnumerable<Product> GetAll()
        {
            var list = new List<Product>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetAllProduct", conn) { CommandType = CommandType.StoredProcedure };
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(new Product { ProductId = (int)reader["ProductId"], ProductName = reader["ProductName"].ToString()!, Price = (int)reader["Price"], Quantity = (int)reader["Quantity"] });
            return list;
        }

        public void Add(Product entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_AddProduct", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@ProductName", entity.ProductName);
            cmd.Parameters.AddWithValue("@Price", entity.Price);
            cmd.Parameters.AddWithValue("@Quantity", entity.Quantity);
            conn.Open(); cmd.ExecuteNonQuery();
        }

        public void Update(Product entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_UpdateProduct", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@ProductId", entity.ProductId);
            cmd.Parameters.AddWithValue("@ProductName", entity.ProductName);
            cmd.Parameters.AddWithValue("@Price", entity.Price);
            cmd.Parameters.AddWithValue("@Quantity", entity.Quantity);
            conn.Open(); cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_DeleteProduct", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@ProductId", id);
            conn.Open(); cmd.ExecuteNonQuery();
        }
    }
}