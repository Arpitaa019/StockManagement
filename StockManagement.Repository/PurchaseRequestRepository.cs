using System.Data;
using System.Data.SqlClient;
using StockManagement.Core;
using StockManagement.Interface;

namespace StockManagement.Repository
{
    public class PurchaseRequestRepository : IPurchaseRequestRepository
    {
        private readonly string _connectionString;
        public PurchaseRequestRepository(string connectionString) { _connectionString = connectionString; }

        public IEnumerable<PurchaseRequestMaster> GetAll()
        {
            var list = new List<PurchaseRequestMaster>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetAllPurchaseRequests", conn) { CommandType = CommandType.StoredProcedure };
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(MapMaster(reader));
            return list;
        }

        public PurchaseRequestMaster? GetById(int id)
        {
            PurchaseRequestMaster? master = null;
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetPurchaseRequestById", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@PRId", id);
            conn.Open();
            using var reader = cmd.ExecuteReader();

            // First result set: master
            if (reader.Read())
                master = MapMaster(reader);

            // Second result set: details
            if (master != null && reader.NextResult())
            {
                while (reader.Read())
                    master.Items.Add(MapDetail(reader));
            }

            return master;
        }

        public void Add(PurchaseRequestMaster entity)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var tran = conn.BeginTransaction();
            try
            {
                // Insert master, get new PRId
                using var masterCmd = new SqlCommand("sp_AddPurchaseRequest", conn, tran) { CommandType = CommandType.StoredProcedure };
                AddMasterParameters(masterCmd, entity);
                var newIdParam = new SqlParameter("@NewPRId", SqlDbType.Int) { Direction = ParameterDirection.Output };
                masterCmd.Parameters.Add(newIdParam);
                masterCmd.ExecuteNonQuery();
                int newId = (int)newIdParam.Value;

                // Insert details
                foreach (var item in entity.Items)
                {
                    using var detailCmd = new SqlCommand("sp_AddPurchaseRequestDetail", conn, tran) { CommandType = CommandType.StoredProcedure };
                    AddDetailParameters(detailCmd, item, newId);
                    detailCmd.ExecuteNonQuery();
                }

                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }

        public void Update(PurchaseRequestMaster entity)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var tran = conn.BeginTransaction();
            try
            {
                // Update master
                using var masterCmd = new SqlCommand("sp_UpdatePurchaseRequest", conn, tran) { CommandType = CommandType.StoredProcedure };
                masterCmd.Parameters.AddWithValue("@PRId", entity.PRId);
                AddMasterParameters(masterCmd, entity);
                masterCmd.ExecuteNonQuery();

                // Delete existing details then re-insert
                using var deleteCmd = new SqlCommand("sp_DeletePurchaseRequestDetails", conn, tran) { CommandType = CommandType.StoredProcedure };
                deleteCmd.Parameters.AddWithValue("@PurchaseRequestMasterId", entity.PRId);
                deleteCmd.ExecuteNonQuery();

                foreach (var item in entity.Items)
                {
                    using var detailCmd = new SqlCommand("sp_AddPurchaseRequestDetail", conn, tran) { CommandType = CommandType.StoredProcedure };
                    AddDetailParameters(detailCmd, item, entity.PRId);
                    detailCmd.ExecuteNonQuery();
                }

                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }

        public void Delete(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var tran = conn.BeginTransaction();
            try
            {
                using var deleteDetailsCmd = new SqlCommand("sp_DeletePurchaseRequestDetails", conn, tran) { CommandType = CommandType.StoredProcedure };
                deleteDetailsCmd.Parameters.AddWithValue("@PurchaseRequestMasterId", id);
                deleteDetailsCmd.ExecuteNonQuery();

                using var deleteMasterCmd = new SqlCommand("sp_DeletePurchaseRequest", conn, tran) { CommandType = CommandType.StoredProcedure };
                deleteMasterCmd.Parameters.AddWithValue("@PRId", id);
                deleteMasterCmd.ExecuteNonQuery();

                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }

        private static void AddMasterParameters(SqlCommand cmd, PurchaseRequestMaster entity)
        {
            cmd.Parameters.AddWithValue("@PRNumber",    entity.PRNumber ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@RequestDate", entity.RequestDate);
            cmd.Parameters.AddWithValue("@RequestedBy", entity.RequestedBy ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Department",  entity.Department ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Status",      entity.Status ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Remarks",     entity.Remarks ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@TotalAmount", entity.TotalAmount);
            cmd.Parameters.AddWithValue("@CreatedDate", entity.CreatedDate);
            cmd.Parameters.AddWithValue("@ModifiedDate",entity.ModifiedDate);
        }

        private static void AddDetailParameters(SqlCommand cmd, PurchaseRequestDetails item, int masterId)
        {
            cmd.Parameters.AddWithValue("@PurchaseRequestMasterId", masterId);
            cmd.Parameters.AddWithValue("@ItemCodeNo",    item.ItemCodeNo ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Description",   item.Description ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Quantity",      item.Quantity);
            cmd.Parameters.AddWithValue("@UnitOfMeasure", item.UnitOfMeasure ?? (object)DBNull.Value);
        }

        private static PurchaseRequestMaster MapMaster(SqlDataReader r) => new PurchaseRequestMaster
        {
            PRId         = (int)r["PRId"],
            PRNumber     = r["PRNumber"] as string,
            RequestDate  = (DateTime)r["RequestDate"],
            RequestedBy  = r["RequestedBy"] as string,
            Department   = r["Department"] as string,
            Status       = r["Status"] as string,
            Remarks      = r["Remarks"] as string,
            TotalAmount  = Convert.ToSingle(r["TotalAmount"]),
            CreatedDate  = (DateTime)r["CreatedDate"],
            ModifiedDate = (DateTime)r["ModifiedDate"]
        };

        private static PurchaseRequestDetails MapDetail(SqlDataReader r) => new PurchaseRequestDetails
        {
            PRDetailId               = (int)r["PRDetailId"],
            PurchaseRequestMasterId  = (int)r["PurchaseRequestMasterId"],
            ItemCodeNo               = r["ItemCodeNo"] as string,
            Description              = r["Description"] as string,
            Quantity                 = Convert.ToSingle(r["Quantity"]),
            UnitOfMeasure            = r["UnitOfMeasure"] as string
        };
    }
}
