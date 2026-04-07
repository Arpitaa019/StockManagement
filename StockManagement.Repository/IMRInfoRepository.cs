using System.Data;
using System.Data.SqlClient;
using StockManagement.Entity;
using StockManagement.Interface;

namespace StockManagement.Repository
{
    public class IMRInfoRepository : IIMRInfoRepository
    {
        private readonly string _connectionString;
        public IMRInfoRepository(string connectionString) { _connectionString = connectionString; }

        public IMRInfo? GetById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetIMRInfoById", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@ImrId", id);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                return new IMRInfo { ImrId = (int)reader["ImrId"], ProductId = (int)reader["ProductId"], InspectedBy = reader["InspectedBy"].ToString()!, InspectedDate = (DateTime)reader["InspectedDate"], InspectStatus = reader["InspectStatus"].ToString()!, Remarks = reader["Remarks"].ToString()! };
            return null;
        }

        public IEnumerable<IMRInfo> GetAll()
        {
            var list = new List<IMRInfo>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetAllIMRInfo", conn) { CommandType = CommandType.StoredProcedure };
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(new IMRInfo { ImrId = (int)reader["ImrId"], ProductId = (int)reader["ProductId"], InspectedBy = reader["InspectedBy"].ToString()!, InspectedDate = (DateTime)reader["InspectedDate"], InspectStatus = reader["InspectStatus"].ToString()!, Remarks = reader["Remarks"].ToString()! });
            return list;
        }

        public void Add(IMRInfo entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_AddIMRInfo", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@ProductId", entity.ProductId);
            cmd.Parameters.AddWithValue("@InspectedBy", entity.InspectedBy);
            cmd.Parameters.AddWithValue("@InspectedDate", entity.InspectedDate);
            cmd.Parameters.AddWithValue("@InspectStatus", entity.InspectStatus);
            cmd.Parameters.AddWithValue("@Remarks", entity.Remarks);
            conn.Open(); cmd.ExecuteNonQuery();
        }

        public void Update(IMRInfo entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_UpdateIMRInfo", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@ImrId", entity.ImrId);
            cmd.Parameters.AddWithValue("@ProductId", entity.ProductId);
            cmd.Parameters.AddWithValue("@InspectedBy", entity.InspectedBy);
            cmd.Parameters.AddWithValue("@InspectedDate", entity.InspectedDate);
            cmd.Parameters.AddWithValue("@InspectStatus", entity.InspectStatus);
            cmd.Parameters.AddWithValue("@Remarks", entity.Remarks);
            conn.Open(); cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_DeleteIMRInfo", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@ImrId", id);
            conn.Open(); cmd.ExecuteNonQuery();
        }
    }
}