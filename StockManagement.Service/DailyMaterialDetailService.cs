using StockManagement.Entity;
using StockManagement.Interface;
using StockManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Services
{
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
