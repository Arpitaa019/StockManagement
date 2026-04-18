using StockManagement.Entity;
namespace StockManagement.Interface
{
    public interface IEmployeeRepository
    {
        Employee? GetById(int id);
        IEnumerable<Employee> GetAll();
        void Add(Employee entity);
        void Update(Employee entity);
        void Delete(int id);
    }
}
