using StockManagement.Entity;
using StockManagement.Interface;

namespace StockManagement.Service
{
    public class IMRInfoService : IIMRInfoService
    {
        private readonly IIMRInfoRepository _repo;
        public IMRInfoService(IIMRInfoRepository repo) { _repo = repo; }
        public IMRInfo? Get(int id) => _repo.GetById(id);
        public IEnumerable<IMRInfo> GetAll() => _repo.GetAll();
        public void Create(IMRInfo entity) => _repo.Add(entity);
        public void Update(IMRInfo entity) => _repo.Update(entity);
        public void Delete(int id) => _repo.Delete(id);
    }
}