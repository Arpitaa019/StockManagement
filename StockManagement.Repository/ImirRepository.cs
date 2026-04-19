using System.Data;
using System.Data.SqlClient;
using StockManagement.Entity;
using StockManagement.Interface;

namespace StockManagement.Repository
{
    public class ImirRepository : IIMIRCumulativeRepository
    {
        private readonly string _connectionString;
        public ImirRepository(string connectionString) { _connectionString = connectionString; }

        public IMIRCumulative? GetById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetIMRCumulativeById", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@ImrCumulativeId", id);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                return new IMIRCumulative {
                    ImirCumulativeId = (int)reader["ImrCumulativeId"],
                    ImirId = (int)reader["ImrId"],
                    Quantity = Convert.ToDecimal(reader["Quantity"]),
                    Remarks = reader["Remarks"] as string ?? string.Empty,
                    CreatedDate = (DateTime)reader["CreatedDate"]
                };
            return null;
        }

        public IEnumerable<IMIRCumulative> GetAll()
        {
            var list = new List<IMIRCumulative>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetAllIMRCumulative", conn) { CommandType = CommandType.StoredProcedure };
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(new IMIRCumulative {
                    ImirCumulativeId = (int)reader["ImrCumulativeId"],
                    ImirId = (int)reader["ImrId"],
                    Quantity = Convert.ToDecimal(reader["Quantity"]),
                    Remarks = reader["Remarks"] as string ?? string.Empty,
                    CreatedDate = (DateTime)reader["CreatedDate"]
                });
            return list;
        }

        public void Add(IMIRCumulative entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_AddIMRCumulative", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@ImrId", entity.ImirId);
            cmd.Parameters.AddWithValue("@Quantity", entity.Quantity);
            cmd.Parameters.AddWithValue("@Remarks", (object?)entity.Remarks ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CreatedDate", entity.CreatedDate);
            conn.Open(); cmd.ExecuteNonQuery();
        }

        public void Update(IMIRCumulative entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_UpdateIMRCumulative", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@ImrCumulativeId", entity.ImirCumulativeId);
            cmd.Parameters.AddWithValue("@ImrId", entity.ImirId);
            cmd.Parameters.AddWithValue("@Quantity", entity.Quantity);
            cmd.Parameters.AddWithValue("@Remarks", (object?)entity.Remarks ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CreatedDate", entity.CreatedDate);
            conn.Open(); cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_DeleteIMRCumulative", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@ImrCumulativeId", id);
            conn.Open(); cmd.ExecuteNonQuery();
        }
    }
}
