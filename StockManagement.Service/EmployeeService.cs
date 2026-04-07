using StockManagement.Entity;
using StockManagement.Interface;

namespace StockManagement.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;
        public EmployeeService(IEmployeeRepository repo) { _repo = repo; }
        public Employee? Get(int id) => _repo.GetById(id);
        public IEnumerable<Employee> GetAll() => _repo.GetAll();
        public void Create(Employee entity) => _repo.Add(entity);
        public void Update(Employee entity) => _repo.Update(entity);
        public void Delete(int id) => _repo.Delete(id);
    }
}