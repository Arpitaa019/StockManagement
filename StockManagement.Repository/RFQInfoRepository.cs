using System.Data;
using System.Data.SqlClient;
using StockManagement.Entity;
using StockManagement.Interface;

namespace StockManagement.Repository
{
    public class RFQInfoRepository : IRFQInfoRepository
    {
        private readonly string _connectionString;
        public RFQInfoRepository(string connectionString) { _connectionString = connectionString; }

        public RFQInfo? GetById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetRFQInfoById", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@RfqId", id);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                return new RFQInfo { RfqId = (int)reader["RfqId"], ProductList = reader["ProductList"].ToString()!, IsApproved = (bool)reader["IsApproved"], ApprovedBy = reader["ApprovedBy"].ToString()!, IsFinalApproved = (bool)reader["IsFinalApproved"], FinalApprovedBy = reader["FinalApprovedBy"].ToString()!, CreatedDate = (DateTime)reader["CreatedDate"] };
            return null;
        }

        public IEnumerable<RFQInfo> GetAll()
        {
            var list = new List<RFQInfo>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetAllRFQInfo", conn) { CommandType = CommandType.StoredProcedure };
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(new RFQInfo { RfqId = (int)reader["RfqId"], ProductList = reader["ProductList"].ToString()!, IsApproved = (bool)reader["IsApproved"], ApprovedBy = reader["ApprovedBy"].ToString()!, IsFinalApproved = (bool)reader["IsFinalApproved"], FinalApprovedBy = reader["FinalApprovedBy"].ToString()!, CreatedDate = (DateTime)reader["CreatedDate"] });
            return list;
        }

        public void Add(RFQInfo entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_AddRFQInfo", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@ProductList", entity.ProductList);
            cmd.Parameters.AddWithValue("@IsApproved", entity.IsApproved);
            cmd.Parameters.AddWithValue("@ApprovedBy", entity.ApprovedBy);
            cmd.Parameters.AddWithValue("@IsFinalApproved", entity.IsFinalApproved);
            cmd.Parameters.AddWithValue("@FinalApprovedBy", entity.FinalApprovedBy);
            cmd.Parameters.AddWithValue("@CreatedDate", entity.CreatedDate);
            conn.Open(); cmd.ExecuteNonQuery();
        }

        public void Update(RFQInfo entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_UpdateRFQInfo", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@RfqId", entity.RfqId);
            cmd.Parameters.AddWithValue("@ProductList", entity.ProductList);
            cmd.Parameters.AddWithValue("@IsApproved", entity.IsApproved);
            cmd.Parameters.AddWithValue("@ApprovedBy", entity.ApprovedBy);
            cmd.Parameters.AddWithValue("@IsFinalApproved", entity.IsFinalApproved);
            cmd.Parameters.AddWithValue("@FinalApprovedBy", entity.FinalApprovedBy);
            cmd.Parameters.AddWithValue("@CreatedDate", entity.CreatedDate);
            conn.Open(); cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_DeleteRFQInfo", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@RfqId", id);
            conn.Open(); cmd.ExecuteNonQuery();
        }
    }
}