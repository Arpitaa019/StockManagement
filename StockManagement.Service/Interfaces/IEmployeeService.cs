using StockManagement.Entity;
namespace StockManagement.Interface
{
    public interface IEmployeeService
    {
        Employee? Get(int id);
        IEnumerable<Employee> GetAll();
        void Create(Employee entity);
        void Update(Employee entity);
        void Delete(int id);
    }
}
