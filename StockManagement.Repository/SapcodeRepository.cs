using System.Data;
using System.Data.SqlClient;
using StockManagement.Core;
using StockManagement.Interface;

namespace StockManagement.Repository
{
    public class SapcodeRepository : ISapcodeRepository
    {
        private readonly string _connectionString;
        public SapcodeRepository(string connectionString) { _connectionString = connectionString; }

        public Sapcode? GetById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetSapcodeById", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@ItemCodeDescriptionMasterId", id);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                return MapSapcode(reader);
            return null;
        }

        public IEnumerable<Sapcode> GetAll()
        {
            var list = new List<Sapcode>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetAllSapcodes", conn) { CommandType = CommandType.StoredProcedure };
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(MapSapcode(reader));
            return list;
        }

        public void Add(Sapcode entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_AddSapcode", conn) { CommandType = CommandType.StoredProcedure };
            AddParameters(cmd, entity);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Update(Sapcode entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_UpdateSapcode", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@ItemCodeDescriptionMasterId", entity.ItemCodeDescriptionMasterId);
            AddParameters(cmd, entity);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_DeleteSapcode", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@ItemCodeDescriptionMasterId", id);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        private static void AddParameters(SqlCommand cmd, Sapcode entity)
        {
            cmd.Parameters.AddWithValue("@ItemCodeNo", entity.ItemCodeNo ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ItemType", entity.ItemType ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Material", entity.Material ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@SizeInch", entity.SizeInch ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Weight", entity.Weight ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Color", entity.Color ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@RequiredQty", entity.RequiredQty);
            cmd.Parameters.AddWithValue("@AllocatedQty", entity.AllocatedQty);
            cmd.Parameters.AddWithValue("@IssuedQty", entity.IssuedQty);
            cmd.Parameters.AddWithValue("@UnitOfMeasure", entity.UnitOfMeasure ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@BatchNo", entity.BatchNo ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@HeatNo", entity.HeatNo ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@VendorName", entity.VendorName ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@AllocationDate", entity.AllocationDate);
            cmd.Parameters.AddWithValue("@IssueDate", entity.IssueDate.HasValue ? (object)entity.IssueDate.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@Location", entity.Location ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@IsActive", entity.IsActive);
            cmd.Parameters.AddWithValue("@Remarks", entity.Remarks ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@CreatedDate", entity.CreatedDate);
            cmd.Parameters.AddWithValue("@ModifiedDate", entity.ModifiedDate);
        }

        private static Sapcode MapSapcode(SqlDataReader reader) => new Sapcode
        {
            ItemCodeDescriptionMasterId = (int)reader["ItemCodeDescriptionMasterId"],
            ItemCodeNo      = reader["ItemCodeNo"] as string,
            ItemType        = reader["ItemType"] as string,
            Material        = reader["Material"] as string,
            SizeInch        = reader["SizeInch"] as string,
            Weight          = reader["Weight"] as string,
            Color           = reader["Color"] as string,
            RequiredQty     = Convert.ToSingle(reader["RequiredQty"]),
            AllocatedQty    = Convert.ToSingle(reader["AllocatedQty"]),
            IssuedQty       = Convert.ToSingle(reader["IssuedQty"]),
            UnitOfMeasure   = reader["UnitOfMeasure"] as string,
            BatchNo         = reader["BatchNo"] as string,
            HeatNo          = reader["HeatNo"] as string,
            VendorName      = reader["VendorName"] as string,
            AllocationDate  = (DateTime)reader["AllocationDate"],
            IssueDate       = reader["IssueDate"] as DateTime?,
            Location        = reader["Location"] as string,
            IsActive        = (bool)reader["IsActive"],
            Remarks         = reader["Remarks"] as string,
            CreatedDate     = (DateTime)reader["CreatedDate"],
            ModifiedDate    = (DateTime)reader["ModifiedDate"]
        };
    }
}
