using StockManagement.Entity;
using StockManagement.Interface;

namespace StockManagement.Service
{
    public class RFPInfoService : IRFPInfoService
    {
        private readonly IRFPInfoRepository _repo;
        public RFPInfoService(IRFPInfoRepository repo) { _repo = repo; }
        public RFPInfo? Get(int id) => _repo.GetById(id);
        public IEnumerable<RFPInfo> GetAll() => _repo.GetAll();
        public void Create(RFPInfo entity) => _repo.Add(entity);
        public void Update(RFPInfo entity) => _repo.Update(entity);
        public void Delete(int id) => _repo.Delete(id);
    }
}