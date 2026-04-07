using System.Data;
using System.Data.SqlClient;
using StockManagement.Entity;
using StockManagement.Interface;

namespace StockManagement.Repository
{
    public class RFPInfoRepository : IRFPInfoRepository
    {
        private readonly string _connectionString;
        public RFPInfoRepository(string connectionString) { _connectionString = connectionString; }

        public RFPInfo? GetById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetRFPInfoById", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@RfpId", id);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                return new RFPInfo { RfpId = (int)reader["RfpId"], ProductList = reader["ProductList"].ToString()!, CreatedBy = reader["CreatedBy"].ToString()!, Created = (DateTime)reader["Created"] };
            return null;
        }

        public IEnumerable<RFPInfo> GetAll()
        {
            var list = new List<RFPInfo>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetAllRFPInfo", conn) { CommandType = CommandType.StoredProcedure };
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(new RFPInfo { RfpId = (int)reader["RfpId"], ProductList = reader["ProductList"].ToString()!, CreatedBy = reader["CreatedBy"].ToString()!, Created = (DateTime)reader["Created"] });
            return list;
        }

        public void Add(RFPInfo entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_AddRFPInfo", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@ProductList", entity.ProductList);
            cmd.Parameters.AddWithValue("@CreatedBy", entity.CreatedBy);
            cmd.Parameters.AddWithValue("@Created", entity.Created);
            conn.Open(); cmd.ExecuteNonQuery();
        }

        public void Update(RFPInfo entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_UpdateRFPInfo", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@RfpId", entity.RfpId);
            cmd.Parameters.AddWithValue("@ProductList", entity.ProductList);
            cmd.Parameters.AddWithValue("@CreatedBy", entity.CreatedBy);
            cmd.Parameters.AddWithValue("@Created", entity.Created);
            conn.Open(); cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_DeleteRFPInfo", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@RfpId", id);
            conn.Open(); cmd.ExecuteNonQuery();
        }
    }
}