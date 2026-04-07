using System.Data;
using System.Data.SqlClient;
using StockManagement.Entity;
using StockManagement.Interface;

namespace StockManagement.Repository
{
    public class RequestForApprovalInfoRepository : IRequestForApprovalInfoRepository
    {
        private readonly string _connectionString;
        public RequestForApprovalInfoRepository(string connectionString) { _connectionString = connectionString; }

        private static RequestForApprovalInfo Map(System.Data.Common.DbDataReader r) => new()
        {
            RequestId = (int)r["RequestId"], RfpId = (int)r["RfpId"], ProductId = (int)r["ProductId"],
            RequestedBy = (int)r["RequestedBy"], RequestedDate = (DateTime)r["RequestedDate"],
            IsApproved = (bool)r["IsApproved"], ApprovedBy = r["ApprovedBy"] as int?,
            ApprovedDate = r["ApprovedDate"] as DateTime?, IsFinalApproved = (bool)r["IsFinalApproved"],
            FinalApprovedBy = r["FinalApprovedBy"] as int?, FinalApprovedDate = r["FinalApprovedDate"] as DateTime?,
            Remarks = r["Remarks"].ToString(), Status = r["Status"].ToString()!
        };

        public RequestForApprovalInfo? GetById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetRequestForApprovalById", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@RequestId", id);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            return reader.Read() ? Map(reader) : null;
        }

        public IEnumerable<RequestForApprovalInfo> GetAll()
        {
            var list = new List<RequestForApprovalInfo>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetAllRequestForApproval", conn) { CommandType = CommandType.StoredProcedure };
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) list.Add(Map(reader));
            return list;
        }

        public void Add(RequestForApprovalInfo entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_AddRequestForApproval", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@RfpId", entity.RfpId);
            cmd.Parameters.AddWithValue("@ProductId", entity.ProductId);
            cmd.Parameters.AddWithValue("@RequestedBy", entity.RequestedBy);
            cmd.Parameters.AddWithValue("@RequestedDate", entity.RequestedDate);
            cmd.Parameters.AddWithValue("@IsApproved", entity.IsApproved);
            cmd.Parameters.AddWithValue("@ApprovedBy", (object?)entity.ApprovedBy ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ApprovedDate", (object?)entity.ApprovedDate ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@IsFinalApproved", entity.IsFinalApproved);
            cmd.Parameters.AddWithValue("@FinalApprovedBy", (object?)entity.FinalApprovedBy ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@FinalApprovedDate", (object?)entity.FinalApprovedDate ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Remarks", (object?)entity.Remarks ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Status", entity.Status);
            conn.Open(); cmd.ExecuteNonQuery();
        }

        public void Update(RequestForApprovalInfo entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_UpdateRequestForApproval", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@RequestId", entity.RequestId);
            cmd.Parameters.AddWithValue("@RfpId", entity.RfpId);
            cmd.Parameters.AddWithValue("@ProductId", entity.ProductId);
            cmd.Parameters.AddWithValue("@RequestedBy", entity.RequestedBy);
            cmd.Parameters.AddWithValue("@RequestedDate", entity.RequestedDate);
            cmd.Parameters.AddWithValue("@IsApproved", entity.IsApproved);
            cmd.Parameters.AddWithValue("@ApprovedBy", (object?)entity.ApprovedBy ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ApprovedDate", (object?)entity.ApprovedDate ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@IsFinalApproved", entity.IsFinalApproved);
            cmd.Parameters.AddWithValue("@FinalApprovedBy", (object?)entity.FinalApprovedBy ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@FinalApprovedDate", (object?)entity.FinalApprovedDate ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Remarks", (object?)entity.Remarks ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Status", entity.Status);
            conn.Open(); cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_DeleteRequestForApproval", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@RequestId", id);
            conn.Open(); cmd.ExecuteNonQuery();
        }
    }
}