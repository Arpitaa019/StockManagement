using System.Data;
using System.Data.SqlClient;
using StockManagement.Entity;
using StockManagement.Interface;

namespace StockManagement.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;
        public EmployeeRepository(string connectionString) { _connectionString = connectionString; }

        public Employee? GetById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetEmployeeById", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@EmployeeId", id);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                return new Employee { EmployeeId = (int)reader["EmployeeId"], Name = reader["Name"].ToString()!, Contact = reader["Contact"].ToString()!, Address = reader["Address"].ToString()!, Email = reader["Email"].ToString()!, Created = (DateTime)reader["Created"] };
            return null;
        }

        public IEnumerable<Employee> GetAll()
        {
            var list = new List<Employee>();
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_GetAllEmployee", conn) { CommandType = CommandType.StoredProcedure };
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(new Employee { EmployeeId = (int)reader["EmployeeId"], Name = reader["Name"].ToString()!, Contact = reader["Contact"].ToString()!, Address = reader["Address"].ToString()!, Email = reader["Email"].ToString()!, Created = (DateTime)reader["Created"] });
            return list;
        }

        public void Add(Employee entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_AddEmployee", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@Name", entity.Name);
            cmd.Parameters.AddWithValue("@Contact", entity.Contact);
            cmd.Parameters.AddWithValue("@Address", entity.Address);
            cmd.Parameters.AddWithValue("@Email", entity.Email);
            cmd.Parameters.AddWithValue("@Created", entity.Created);
            conn.Open(); cmd.ExecuteNonQuery();
        }

        public void Update(Employee entity)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_UpdateEmployee", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@EmployeeId", entity.EmployeeId);
            cmd.Parameters.AddWithValue("@Name", entity.Name);
            cmd.Parameters.AddWithValue("@Contact", entity.Contact);
            cmd.Parameters.AddWithValue("@Address", entity.Address);
            cmd.Parameters.AddWithValue("@Email", entity.Email);
            cmd.Parameters.AddWithValue("@Created", entity.Created);
            conn.Open(); cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand("sp_DeleteEmployee", conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@EmployeeId", id);
            conn.Open(); cmd.ExecuteNonQuery();
        }
    }
}