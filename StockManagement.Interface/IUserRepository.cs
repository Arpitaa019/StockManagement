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
    public interface IUserService
    {
        User? Get(int id);
        IEnumerable<User> GetAll();
        void Create(User entity);
        void Update(User entity);
        void Delete(int id);
    }
}
