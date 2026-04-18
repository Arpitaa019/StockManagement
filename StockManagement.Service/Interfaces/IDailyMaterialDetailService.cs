using StockManagement.Entity;

namespace StockManagement.Services.Interfaces
{
    public interface IDailyMaterialDetailService
    {
        DailyMaterialDetail? Get(int id);
        IEnumerable<DailyMaterialDetail> GetByDmrId(int dmrId);
        void Create(DailyMaterialDetail entity);
        void Update(DailyMaterialDetail entity);
        void Delete(int id);
    }
}
