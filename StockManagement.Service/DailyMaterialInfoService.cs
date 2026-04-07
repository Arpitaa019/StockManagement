using StockManagement.Entity;
using StockManagement.Interface;

namespace StockManagement.Service
{
    public class DailyMaterialInfoService : IDailyMaterialInfoService
    {
        private readonly IDailyMaterialInfoRepository _repo;
        public DailyMaterialInfoService(IDailyMaterialInfoRepository repo) { _repo = repo; }
        public DailyMaterialInfo? Get(int id) => _repo.GetById(id);
        public IEnumerable<DailyMaterialInfo> GetAll() => _repo.GetAll();
        public void Create(DailyMaterialInfo entity) => _repo.Add(entity);
        public void Update(DailyMaterialInfo entity) => _repo.Update(entity);
        public void Delete(int id) => _repo.Delete(id);
    }

    public class DailyMaterialDetailService : IDailyMaterialDetailService
    {
        private readonly IDailyMaterialDetailRepository _repo;
        public DailyMaterialDetailService(IDailyMaterialDetailRepository repo) { _repo = repo; }
        public DailyMaterialDetail? Get(int id) => _repo.GetById(id);
        public IEnumerable<DailyMaterialDetail> GetByDmrId(int dmrId) => _repo.GetByDmrId(dmrId);
        public void Create(DailyMaterialDetail entity) => _repo.Add(entity);
        public void Update(DailyMaterialDetail entity) => _repo.Update(entity);
        public void Delete(int id) => _repo.Delete(id);
    }
}