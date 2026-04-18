using StockManagement.Entity;
namespace StockManagement.Interface
{
    public interface IUserService
    {
        User? Get(int id);
        IEnumerable<User> GetAll();
        void Create(User entity);
        void Update(User entity);
        void Delete(int id);
    }
}
