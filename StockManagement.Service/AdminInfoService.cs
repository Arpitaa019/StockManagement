using StockManagement.Entity;
using StockManagement.Interface;

namespace StockManagement.Service
{
    public class AdminInfoService : IAdminInfoService
    {
        private readonly IAdminInfoRepository _repo;
        public AdminInfoService(IAdminInfoRepository repo) { _repo = repo; }
        public AdminInfo? Get(int id) => _repo.GetById(id);
        public IEnumerable<AdminInfo> GetAll() => _repo.GetAll();
        public void Create(AdminInfo entity) => _repo.Add(entity);
        public void Update(AdminInfo entity) => _repo.Update(entity);
        public void Delete(int id) => _repo.Delete(id);
    }
}