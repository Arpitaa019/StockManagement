using StockManagement.Entity;
namespace StockManagement.Interface
{
    public interface IUserRepository
    {
        User? GetById(int id);
        IEnumerable<User> GetAll();
        void Add(User entity);
        void Update(User entity);
        void Delete(int id);
    }
}
