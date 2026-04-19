using System.Data;
using System.Data.SqlClient;
using StockManagement.Entity;
using StockManagement.Interface;

namespace StockManagement.Repository
{
    public class DMRRepository : IDMRRepository
    {
        private readonly string _connectionString;
        public DMRRepository(string connectionString) { _connectionString = connectionString; }

        public DMRMaster? GetById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_DMR_GetById", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@DmrId", id);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                return new DMRMaster {
                    DmrId = (int)reader["DmrId"],
                    POId = reader["POId"] as int? ?? (reader["POId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["POId"])),
                    PONumber = reader["PONumber"] as string ?? string.Empty,
                    VendorId = (int)reader["VendorId"],
                    DeliveryDate = (DateTime)reader["DeliveryDate"],
                    ApprovedBy = reader["ApprovedBy"].ToString()!,
                    IsFinalized = (bool)reader["IsFinalized"],
                    FinalizedDate = reader["FinalizedDate"] as DateTime?,
                    Remarks = reader["Remarks"].ToString()
                };
            return null;
        }

        public IEnumerable<DMRMaster> GetAll()
        {
            var list = new List<DMRMaster>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_DMR_GetAll", conn) { CommandType = CommandType.StoredProcedure };
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(new DMRMaster {
                    DmrId = (int)reader["DmrId"],
                    POId = reader["POId"] as int? ?? (reader["POId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["POId"])),
                    PONumber = reader["PONumber"] as string ?? string.Empty,
                    VendorId = (int)reader["VendorId"],
                    DeliveryDate = (DateTime)reader["DeliveryDate"],
                    ApprovedBy = reader["ApprovedBy"].ToString()!,
                    IsFinalized = (bool)reader["IsFinalized"],
                    FinalizedDate = reader["FinalizedDate"] as DateTime?,
                    Remarks = reader["Remarks"].ToString()
                });
            return list;
        }

        public void Add(DMRMaster entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_DMR_Add", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@VendorId", entity.VendorId);
            cmd.Parameters.AddWithValue("@POId", (object?)entity.POId ?? DBNull.Value);
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
            using var cmd = new SqlCommand("sp_DMR_Update", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@DmrId", entity.DmrId);
            cmd.Parameters.AddWithValue("@VendorId", entity.VendorId);
            cmd.Parameters.AddWithValue("@POId", (object?)entity.POId ?? DBNull.Value);
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
            using var cmd = new SqlCommand("sp_DMR_Delete", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@DmrId", id);
            conn.Open(); cmd.ExecuteNonQuery();
        }
    }

    public class DMRDetailRepository : IDMRDetailRepository
    {
        private readonly string _connectionString;
        public DMRDetailRepository(string connectionString) { _connectionString = connectionString; }

        public DmrDetails? GetById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_DMRDetail_GetById", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@DmrDetailId", id);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                return new DmrDetails { DmrDetailId = (int)reader["DmrDetailId"], DmrId = (int)reader["DmrId"], ProductId = (int)reader["ProductId"], Quantity = (int)reader["Quantity"], Status = reader["Status"].ToString()! };
            return null;
        }

        public IEnumerable<DmrDetails> GetByDmrId(int dmrId)
        {
            var list = new List<DmrDetails>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_DMRDetail_GetByDmrId", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@DmrId", dmrId);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(new DmrDetails { DmrDetailId = (int)reader["DmrDetailId"], DmrId = (int)reader["DmrId"], ProductId = (int)reader["ProductId"], Quantity = (int)reader["Quantity"], Status = reader["Status"].ToString()! });
            return list;
        }

        public void Add(DmrDetails entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_DMRDetail_Add", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@DmrId", entity.DmrId);
            cmd.Parameters.AddWithValue("@ProductId", entity.ProductId);
            cmd.Parameters.AddWithValue("@Quantity", entity.Quantity);
            cmd.Parameters.AddWithValue("@Status", entity.Status);
            conn.Open(); cmd.ExecuteNonQuery();
        }

        public void Update(DmrDetails entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_DMRDetail_Update", conn) { CommandType = CommandType.StoredProcedure };
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
            using var cmd = new SqlCommand("sp_DMRDetail_Delete", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@DmrDetailId", id);
            conn.Open(); cmd.ExecuteNonQuery();
        }
    }
}