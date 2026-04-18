using System.Data;
using System.Data.SqlClient;
using StockManagement.Entity;
using StockManagement.Interface;

namespace StockManagement.Repository
{
    public class InvoiceInfoRepository : IInvoiceInfoRepository
    {
        private readonly string _connectionString;
        public InvoiceInfoRepository(string connectionString) { _connectionString = connectionString; }

        public InvoiceMaster? GetById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetInvoiceInfoById", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@InvoiceId", id);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                return new InvoiceMaster { InvoiceId = (int)reader["InvoiceId"], DmrId = (int)reader["DmrId"], VendorId = (int)reader["VendorId"], TotalAmount = (int)reader["TotalAmount"], InvoiceDate = (DateTime)reader["InvoiceDate"], CreatedBy = reader["CreatedBy"].ToString()!, Status = reader["Status"].ToString()! };
            return null;
        }

        public IEnumerable<InvoiceMaster> GetAll()
        {
            var list = new List<InvoiceMaster>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetAllInvoiceInfo", conn) { CommandType = CommandType.StoredProcedure };
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(new InvoiceMaster { InvoiceId = (int)reader["InvoiceId"], DmrId = (int)reader["DmrId"], VendorId = (int)reader["VendorId"], TotalAmount = (int)reader["TotalAmount"], InvoiceDate = (DateTime)reader["InvoiceDate"], CreatedBy = reader["CreatedBy"].ToString()!, Status = reader["Status"].ToString()! });
            return list;
        }

        public void Add(InvoiceMaster entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_AddInvoiceInfo", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@DmrId", entity.DmrId);
            cmd.Parameters.AddWithValue("@VendorId", entity.VendorId);
            cmd.Parameters.AddWithValue("@TotalAmount", entity.TotalAmount);
            cmd.Parameters.AddWithValue("@InvoiceDate", entity.InvoiceDate);
            cmd.Parameters.AddWithValue("@CreatedBy", entity.CreatedBy);
            cmd.Parameters.AddWithValue("@Status", entity.Status);
            conn.Open(); cmd.ExecuteNonQuery();
        }

        public void Update(InvoiceMaster entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_UpdateInvoiceInfo", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@InvoiceId", entity.InvoiceId);
            cmd.Parameters.AddWithValue("@DmrId", entity.DmrId);
            cmd.Parameters.AddWithValue("@VendorId", entity.VendorId);
            cmd.Parameters.AddWithValue("@TotalAmount", entity.TotalAmount);
            cmd.Parameters.AddWithValue("@InvoiceDate", entity.InvoiceDate);
            cmd.Parameters.AddWithValue("@CreatedBy", entity.CreatedBy);
            cmd.Parameters.AddWithValue("@Status", entity.Status);
            conn.Open(); cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_DeleteInvoiceInfo", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@InvoiceId", id);
            conn.Open(); cmd.ExecuteNonQuery();
        }
    }
}