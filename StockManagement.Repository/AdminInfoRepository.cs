using System.Data;
using System.Data.SqlClient;
using StockManagement.Entity;
using StockManagement.Interface;

namespace StockManagement.Repository
{
    public class AdminInfoRepository : IAdminInfoRepository
    {
        private readonly string _connectionString;
        public AdminInfoRepository(string connectionString) { _connectionString = connectionString; }

        public AdminInfo? GetById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetAdminInfoById", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@AdminId", id);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                return new AdminInfo { AdminId = (int)reader["AdminId"], Name = reader["Name"].ToString()!, Password = reader["Password"].ToString()!, Email = reader["Email"].ToString()!, Created = (DateTime)reader["Created"] };
            return null;
        }

        public IEnumerable<AdminInfo> GetAll()
        {
            var list = new List<AdminInfo>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetAllAdminInfo", conn) { CommandType = CommandType.StoredProcedure };
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(new AdminInfo { AdminId = (int)reader["AdminId"], Name = reader["Name"].ToString()!, Password = reader["Password"].ToString()!, Email = reader["Email"].ToString()!, Created = (DateTime)reader["Created"] });
            return list;
        }

        public void Add(AdminInfo entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_AddAdminInfo", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Name", entity.Name);
            cmd.Parameters.AddWithValue("@Password", entity.Password);
            cmd.Parameters.AddWithValue("@Email", entity.Email);
            cmd.Parameters.AddWithValue("@Created", entity.Created);
            conn.Open(); cmd.ExecuteNonQuery();
        }

        public void Update(AdminInfo entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_UpdateAdminInfo", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@AdminId", entity.AdminId);
            cmd.Parameters.AddWithValue("@Name", entity.Name);
            cmd.Parameters.AddWithValue("@Password", entity.Password);
            cmd.Parameters.AddWithValue("@Email", entity.Email);
            cmd.Parameters.AddWithValue("@Created", entity.Created);
            conn.Open(); cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_DeleteAdminInfo", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@AdminId", id);
            conn.Open(); cmd.ExecuteNonQuery();
        }
    }
}