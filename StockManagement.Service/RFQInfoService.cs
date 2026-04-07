using StockManagement.Entity;
using StockManagement.Interface;

namespace StockManagement.Service
{
    public class RFQInfoService : IRFQInfoService
    {
        private readonly IRFQInfoRepository _repo;
        public RFQInfoService(IRFQInfoRepository repo) { _repo = repo; }
        public RFQInfo? Get(int id) => _repo.GetById(id);
        public IEnumerable<RFQInfo> GetAll() => _repo.GetAll();
        public void Create(RFQInfo entity) => _repo.Add(entity);
        public void Update(RFQInfo entity) => _repo.Update(entity);
        public void Delete(int id) => _repo.Delete(id);
    }
}