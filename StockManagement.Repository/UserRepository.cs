using System.Data;
using System.Data.SqlClient;
using StockManagement.Entity;
using StockManagement.Interface;

namespace StockManagement.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;
        public UserRepository(string connectionString) { _connectionString = connectionString; }

        public User? GetById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetUserById", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@UserId", id);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                return new User { UserId = (int)reader["UserId"], UserName = reader["UserName"].ToString()!, Password = reader["Password"].ToString()!, Email = reader["Email"].ToString()!, Role = reader["Role"].ToString()!, CreatedDate = (DateTime)reader["CreatedDate"] };
            return null;
        }

        public IEnumerable<User> GetAll()
        {
            var list = new List<User>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetAllUser", conn) { CommandType = CommandType.StoredProcedure };
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(new User { UserId = (int)reader["UserId"], UserName = reader["UserName"].ToString()!, Password = reader["Password"].ToString()!, Email = reader["Email"].ToString()!, Role = reader["Role"].ToString()!, CreatedDate = (DateTime)reader["CreatedDate"] });
            return list;
        }

        public void Add(User entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_AddUser", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@UserName", entity.UserName);
            cmd.Parameters.AddWithValue("@Password", entity.Password);
            cmd.Parameters.AddWithValue("@Email", entity.Email);
            cmd.Parameters.AddWithValue("@Role", entity.Role);
            cmd.Parameters.AddWithValue("@CreatedDate", entity.CreatedDate);
            conn.Open(); cmd.ExecuteNonQuery();
        }

        public void Update(User entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_UpdateUser", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@UserId", entity.UserId);
            cmd.Parameters.AddWithValue("@UserName", entity.UserName);
            cmd.Parameters.AddWithValue("@Password", entity.Password);
            cmd.Parameters.AddWithValue("@Email", entity.Email);
            cmd.Parameters.AddWithValue("@Role", entity.Role);
            cmd.Parameters.AddWithValue("@CreatedDate", entity.CreatedDate);
            conn.Open(); cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_DeleteUser", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@UserId", id);
            conn.Open(); cmd.ExecuteNonQuery();
        }
    }
}