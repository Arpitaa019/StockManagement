using System.Data;
using System.Data.SqlClient;
using StockManagement.Entity;
using StockManagement.Interface;

namespace StockManagement.Repository
{
    public class IMRCumulativeRepository : IIMRCumulativeRepository
    {
        private readonly string _connectionString;
        public IMRCumulativeRepository(string connectionString) { _connectionString = connectionString; }

        public IMRCumulative? GetById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetIMRCumulativeById", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@ImrCumulativeId", id);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                return new IMRCumulative {
                    ImrCumulativeId = (int)reader["ImrCumulativeId"],
                    ImrId = (int)reader["ImrId"],
                    Quantity = Convert.ToDecimal(reader["Quantity"]),
                    Remarks = reader["Remarks"] as string ?? string.Empty,
                    CreatedDate = (DateTime)reader["CreatedDate"]
                };
            return null;
        }

        public IEnumerable<IMRCumulative> GetAll()
        {
            var list = new List<IMRCumulative>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetAllIMRCumulative", conn) { CommandType = CommandType.StoredProcedure };
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(new IMRCumulative {
                    ImrCumulativeId = (int)reader["ImrCumulativeId"],
                    ImrId = (int)reader["ImrId"],
                    Quantity = Convert.ToDecimal(reader["Quantity"]),
                    Remarks = reader["Remarks"] as string ?? string.Empty,
                    CreatedDate = (DateTime)reader["CreatedDate"]
                });
            return list;
        }

        public void Add(IMRCumulative entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_AddIMRCumulative", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@ImrId", entity.ImrId);
            cmd.Parameters.AddWithValue("@Quantity", entity.Quantity);
            cmd.Parameters.AddWithValue("@Remarks", (object?)entity.Remarks ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CreatedDate", entity.CreatedDate);
            conn.Open(); cmd.ExecuteNonQuery();
        }

        public void Update(IMRCumulative entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_UpdateIMRCumulative", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@ImrCumulativeId", entity.ImrCumulativeId);
            cmd.Parameters.AddWithValue("@ImrId", entity.ImrId);
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
