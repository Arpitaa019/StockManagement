using System.Data;
using System.Data.SqlClient;
using StockManagement.Core;
using StockManagement.Interface;

namespace StockManagement.Repository
{
    public class VendorRepository : IVendorRepository
    {
        private readonly string _connectionString;
        public VendorRepository(string connectionString) { _connectionString = connectionString; }

        public Vendor? GetById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetVendorById", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@VendorId", id);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                return MapVendor(reader);
            return null;
        }

        public IEnumerable<Vendor> GetAll()
        {
            var list = new List<Vendor>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetAllVendors", conn) { CommandType = CommandType.StoredProcedure };
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(MapVendor(reader));
            return list;
        }

        public void Add(Vendor entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_AddVendor", conn) { CommandType = CommandType.StoredProcedure };
            AddParameters(cmd, entity);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Update(Vendor entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_UpdateVendor", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@VendorId", entity.VendorId);
            AddParameters(cmd, entity);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_DeleteVendor", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@VendorId", id);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        private static void AddParameters(SqlCommand cmd, Vendor entity)
        {
            cmd.Parameters.AddWithValue("@Name", entity.Name);
            cmd.Parameters.AddWithValue("@Contact", entity.Contact ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Address", entity.Address ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", entity.Email ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Phone", entity.Phone ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@GSTNumber", entity.GSTNumber ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@PANNumber", entity.PANNumber ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@BankAccount", entity.BankAccount ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@IFSCCode", entity.IFSCCode ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Country", entity.Country ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@State", entity.State ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@City", entity.City ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@PostalCode", entity.PostalCode ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@VendorType", entity.VendorType ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@IsActive", entity.IsActive);
            cmd.Parameters.AddWithValue("@CreatedDate", entity.CreatedDate);
            cmd.Parameters.AddWithValue("@ModifiedDate", entity.ModifiedDate.HasValue ? (object)entity.ModifiedDate.Value : DBNull.Value);
        }

        private static Vendor MapVendor(SqlDataReader reader) => new Vendor
        {
            VendorId    = (int)reader["VendorId"],
            Name        = reader["Name"].ToString()!,
            Contact     = reader["Contact"] as string,
            Address     = reader["Address"] as string,
            Email       = reader["Email"] as string,
            Phone       = reader["Phone"] as string,
            GSTNumber   = reader["GSTNumber"] as string,
            PANNumber   = reader["PANNumber"] as string,
            BankAccount = reader["BankAccount"] as string,
            IFSCCode    = reader["IFSCCode"] as string,
            Country     = reader["Country"] as string,
            State       = reader["State"] as string,
            City        = reader["City"] as string,
            PostalCode  = reader["PostalCode"] as string,
            VendorType  = reader["VendorType"] as string,
            IsActive    = (bool)reader["IsActive"],
            CreatedDate = (DateTime)reader["CreatedDate"],
            ModifiedDate = reader["ModifiedDate"] as DateTime?
        };
    }
}
