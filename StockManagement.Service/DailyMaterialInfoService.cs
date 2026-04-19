using StockManagement.Entity;
using StockManagement.Interface;

namespace StockManagement.Service
{
    public class DailyMaterialInfoService : IDailyMaterialInfoService
    {
        private readonly IDMRRepository _repo;
        public DailyMaterialInfoService(IDMRRepository repo) { _repo = repo; }
        public DMRMaster? Get(int id) => _repo.GetById(id);
        public IEnumerable<DMRMaster> GetAll() => _repo.GetAll();
        public void Create(DMRMaster entity) => _repo.Add(entity);
        public void Update(DMRMaster entity) => _repo.Update(entity);
        public void Delete(int id) => _repo.Delete(id);
    }
}