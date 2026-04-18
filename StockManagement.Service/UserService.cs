using StockManagement.Entity;
using StockManagement.Interface;

namespace StockManagement.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo) { _repo = repo; }

        public User? Get(int id) => _repo.GetById(id);
        public IEnumerable<User> GetAll() => _repo.GetAll();
        public void Create(User entity) => _repo.Add(entity);
        public void Update(User entity) => _repo.Update(entity);
        public void Delete(int id) => _repo.Delete(id);
    }
}