using System.Data;
using System.Data.SqlClient;
using StockManagement.Entity;
using StockManagement.Interface;

namespace StockManagement.Repository
{
    public class DailyMaterialInfoRepository : IDailyMaterialInfoRepository
    {
        private readonly string _connectionString;
        public DailyMaterialInfoRepository(string connectionString) { _connectionString = connectionString; }

        public DMRMaster? GetById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetDailyMaterialInfoById", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@DmrId", id);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                return new DMRMaster { DmrId = (int)reader["DmrId"], VendorId = (int)reader["VendorId"], DeliveryDate = (DateTime)reader["DeliveryDate"], ApprovedBy = reader["ApprovedBy"].ToString()!, IsFinalized = (bool)reader["IsFinalized"], FinalizedDate = reader["FinalizedDate"] as DateTime?, Remarks = reader["Remarks"].ToString() };
            return null;
        }

        public IEnumerable<DMRMaster> GetAll()
        {
            var list = new List<DMRMaster>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetAllDailyMaterialInfo", conn) { CommandType = CommandType.StoredProcedure };
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(new DMRMaster { DmrId = (int)reader["DmrId"], VendorId = (int)reader["VendorId"], DeliveryDate = (DateTime)reader["DeliveryDate"], ApprovedBy = reader["ApprovedBy"].ToString()!, IsFinalized = (bool)reader["IsFinalized"], FinalizedDate = reader["FinalizedDate"] as DateTime?, Remarks = reader["Remarks"].ToString() });
            return list;
        }

        public void Add(DMRMaster entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_AddDailyMaterialInfo", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@VendorId", entity.VendorId);
            cmd.Parameters.AddWithValue("@DeliveryDate", entity.DeliveryDate);
            cmd.Parameters.AddWithValue("@ApprovedBy", entity.ApprovedBy);
            cmd.Parameters.AddWithValue("@IsFinalized", entity.IsFinalized);
            cmd.Parameters.AddWithValue("@FinalizedDate", (object?)entity.FinalizedDate ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Remarks", (object?)entity.Remarks ?? DBNull.Value);
            conn.Open(); cmd.ExecuteNonQuery();
        }

        public void Update(DMRMaster entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_UpdateDailyMaterialInfo", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@DmrId", entity.DmrId);
            cmd.Parameters.AddWithValue("@VendorId", entity.VendorId);
            cmd.Parameters.AddWithValue("@DeliveryDate", entity.DeliveryDate);
            cmd.Parameters.AddWithValue("@ApprovedBy", entity.ApprovedBy);
            cmd.Parameters.AddWithValue("@IsFinalized", entity.IsFinalized);
            cmd.Parameters.AddWithValue("@FinalizedDate", (object?)entity.FinalizedDate ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Remarks", (object?)entity.Remarks ?? DBNull.Value);
            conn.Open(); cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_DeleteDailyMaterialInfo", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@DmrId", id);
            conn.Open(); cmd.ExecuteNonQuery();
        }
    }

    public class DailyMaterialDetailRepository : IDailyMaterialDetailRepository
    {
        private readonly string _connectionString;
        public DailyMaterialDetailRepository(string connectionString) { _connectionString = connectionString; }

        public DailyMaterialDetail? GetById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetDailyMaterialDetailById", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@DmrDetailId", id);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                return new DailyMaterialDetail { DmrDetailId = (int)reader["DmrDetailId"], DmrId = (int)reader["DmrId"], ProductId = (int)reader["ProductId"], Quantity = (int)reader["Quantity"], Status = reader["Status"].ToString()! };
            return null;
        }

        public IEnumerable<DailyMaterialDetail> GetByDmrId(int dmrId)
        {
            var list = new List<DailyMaterialDetail>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetDailyMaterialDetailByDmrId", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@DmrId", dmrId);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(new DailyMaterialDetail { DmrDetailId = (int)reader["DmrDetailId"], DmrId = (int)reader["DmrId"], ProductId = (int)reader["ProductId"], Quantity = (int)reader["Quantity"], Status = reader["Status"].ToString()! });
            return list;
        }

        public void Add(DailyMaterialDetail entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_AddDailyMaterialDetail", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@DmrId", entity.DmrId);
            cmd.Parameters.AddWithValue("@ProductId", entity.ProductId);
            cmd.Parameters.AddWithValue("@Quantity", entity.Quantity);
            cmd.Parameters.AddWithValue("@Status", entity.Status);
            conn.Open(); cmd.ExecuteNonQuery();
        }

        public void Update(DailyMaterialDetail entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_UpdateDailyMaterialDetail", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@DmrDetailId", entity.DmrDetailId);
            cmd.Parameters.AddWithValue("@DmrId", entity.DmrId);
            cmd.Parameters.AddWithValue("@ProductId", entity.ProductId);
            cmd.Parameters.AddWithValue("@Quantity", entity.Quantity);
            cmd.Parameters.AddWithValue("@Status", entity.Status);
            conn.Open(); cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_DeleteDailyMaterialDetail", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@DmrDetailId", id);
            conn.Open(); cmd.ExecuteNonQuery();
        }
    }
}