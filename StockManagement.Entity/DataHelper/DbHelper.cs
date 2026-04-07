using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StockManagement.Entity.DataHelper
{
    /// <summary>
    /// DbHelper class to manage SQL Server connections and commands.
    /// Provides reusable methods for executing queries and stored procedures.
    /// </summary>
    public class DbHelper : IDisposable
    {
        private readonly string _connectionString;
        private SqlConnection _conn;

        public DbHelper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _conn = new SqlConnection(_connectionString);
        }

        private void OpenConnection()
        {
            if (_conn.State != ConnectionState.Open)
                _conn.Open();
        }

        /// <summary>
        /// Executes a non-query (INSERT, UPDATE, DELETE).
        /// </summary>
        public async Task<int> ExecuteNonQueryAsync(string sp_InsertProduct, SqlParameter[] parameters = null)
        {
            OpenConnection();
            using (SqlCommand cmd = new SqlCommand(sp_InsertProduct, _conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                return await cmd.ExecuteNonQueryAsync();
            }
        }

        /// <summary>
        /// Executes a scalar query (returns single value).
        /// </summary>
        public async Task<object> ExecuteScalarAsync(string spName, SqlParameter[] parameters = null)
        {
            OpenConnection();
            using (SqlCommand cmd = new SqlCommand(spName, _conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                return await cmd.ExecuteScalarAsync();
            }
        }

        /// <summary>
        /// Executes a query and returns a DataTable.
        /// </summary>
        public async Task<DataTable> ExecuteDataTableAsync(string spName, SqlParameter[] parameters = null)
        {
            OpenConnection();
            using (SqlCommand cmd = new SqlCommand(spName, _conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                 if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        /// <summary>
        /// Dispose connection properly.
        /// </summary>
        public void Dispose()
        {
            if (_conn != null)
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();

                _conn.Dispose();
            }
        }

    }
}
