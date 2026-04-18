using System.Data;
using System.Data.SqlClient;
using StockManagement.Core;
using StockManagement.Interface;

namespace StockManagement.Repository
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly string _connectionString;
        public PurchaseOrderRepository(string connectionString) { _connectionString = connectionString; }

        public IEnumerable<PurchaseOrderMaster> GetAll()
        {
            var list = new List<PurchaseOrderMaster>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetAllPurchaseOrders", conn) { CommandType = CommandType.StoredProcedure };
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(MapMaster(reader));
            return list;
        }

        public PurchaseOrderMaster? GetById(int id)
        {
            PurchaseOrderMaster? master = null;
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetPurchaseOrderById", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@POId", id);
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

        public void Add(PurchaseOrderMaster entity)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var tran = conn.BeginTransaction();
            try
            {
                using var masterCmd = new SqlCommand("sp_AddPurchaseOrder", conn, tran) { CommandType = CommandType.StoredProcedure };
                AddMasterParameters(masterCmd, entity);
                var newIdParam = new SqlParameter("@NewPOId", SqlDbType.Int) { Direction = ParameterDirection.Output };
                masterCmd.Parameters.Add(newIdParam);
                masterCmd.ExecuteNonQuery();
                int newId = (int)newIdParam.Value;

                foreach (var item in entity.Items)
                {
                    using var detailCmd = new SqlCommand("sp_AddPurchaseOrderDetail", conn, tran) { CommandType = CommandType.StoredProcedure };
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

        public void Update(PurchaseOrderMaster entity)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            using var tran = conn.BeginTransaction();
            try
            {
                using var masterCmd = new SqlCommand("sp_UpdatePurchaseOrder", conn, tran) { CommandType = CommandType.StoredProcedure };
                masterCmd.Parameters.AddWithValue("@POId", entity.POId);
                AddMasterParameters(masterCmd, entity);
                masterCmd.ExecuteNonQuery();

                using var deleteCmd = new SqlCommand("sp_DeletePurchaseOrderDetails", conn, tran) { CommandType = CommandType.StoredProcedure };
                deleteCmd.Parameters.AddWithValue("@PurchaseOrderMasterId", entity.POId);
                deleteCmd.ExecuteNonQuery();

                foreach (var item in entity.Items)
                {
                    using var detailCmd = new SqlCommand("sp_AddPurchaseOrderDetail", conn, tran) { CommandType = CommandType.StoredProcedure };
                    AddDetailParameters(detailCmd, item, entity.POId);
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
                using var deleteDetailsCmd = new SqlCommand("sp_DeletePurchaseOrderDetails", conn, tran) { CommandType = CommandType.StoredProcedure };
                deleteDetailsCmd.Parameters.AddWithValue("@PurchaseOrderMasterId", id);
                deleteDetailsCmd.ExecuteNonQuery();

                using var deleteMasterCmd = new SqlCommand("sp_DeletePurchaseOrder", conn, tran) { CommandType = CommandType.StoredProcedure };
                deleteMasterCmd.Parameters.AddWithValue("@POId", id);
                deleteMasterCmd.ExecuteNonQuery();

                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }

        private static void AddMasterParameters(SqlCommand cmd, PurchaseOrderMaster entity)
        {
            cmd.Parameters.AddWithValue("@PONumber",     entity.PONumber ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@PRId",         entity.PRId);
            cmd.Parameters.AddWithValue("@PRNumber",     entity.PRNumber ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@VendorId",     entity.VendorId);
            cmd.Parameters.AddWithValue("@VendorName",   entity.VendorName ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@OrderDate",    entity.OrderDate);
            cmd.Parameters.AddWithValue("@DeliveryDate", entity.DeliveryDate);
            cmd.Parameters.AddWithValue("@Department",   entity.Department ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Status",       entity.Status ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@TotalAmount",  entity.TotalAmount);
            cmd.Parameters.AddWithValue("@Remarks",      entity.Remarks ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@CreatedDate",  entity.CreatedDate);
            cmd.Parameters.AddWithValue("@ModifiedDate", entity.ModifiedDate);
        }

        private static void AddDetailParameters(SqlCommand cmd, PurchaseOrderDetails item, int masterId)
        {
            cmd.Parameters.AddWithValue("@PurchaseOrderMasterId", masterId);
            cmd.Parameters.AddWithValue("@ItemCodeNo",    item.ItemCodeNo ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Description",   item.Description ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Quantity",      item.Quantity);
            cmd.Parameters.AddWithValue("@UnitOfMeasure", item.UnitOfMeasure ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@UnitPrice",     item.UnitPrice);
            cmd.Parameters.AddWithValue("@TotalPrice",    item.TotalPrice);
        }

        private static PurchaseOrderMaster MapMaster(SqlDataReader r) => new PurchaseOrderMaster
        {
            POId         = (int)r["POId"],
            PONumber     = r["PONumber"] as string,
            PRId         = r["PRId"] != DBNull.Value ? (int)r["PRId"] : 0,
            PRNumber     = r["PRNumber"] as string,
            VendorId     = r["VendorId"] != DBNull.Value ? (int)r["VendorId"] : 0,
            VendorName   = r["VendorName"] as string,
            OrderDate    = (DateTime)r["OrderDate"],
            DeliveryDate = (DateTime)r["DeliveryDate"],
            Department   = r["Department"] as string,
            Status       = r["Status"] as string,
            TotalAmount  = Convert.ToSingle(r["TotalAmount"]),
            Remarks      = r["Remarks"] as string,
            CreatedDate  = (DateTime)r["CreatedDate"],
            ModifiedDate = (DateTime)r["ModifiedDate"]
        };

        private static PurchaseOrderDetails MapDetail(SqlDataReader r) => new PurchaseOrderDetails
        {
            PODetailId              = (int)r["PODetailId"],
            PurchaseOrderMasterId   = (int)r["PurchaseOrderMasterId"],
            ItemCodeNo              = r["ItemCodeNo"] as string,
            Description             = r["Description"] as string,
            Quantity                = Convert.ToSingle(r["Quantity"]),
            UnitOfMeasure           = r["UnitOfMeasure"] as string,
            UnitPrice               = Convert.ToSingle(r["UnitPrice"]),
            TotalPrice              = Convert.ToSingle(r["TotalPrice"])
        };
    }
}
