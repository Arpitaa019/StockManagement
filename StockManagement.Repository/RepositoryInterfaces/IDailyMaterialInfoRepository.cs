using StockManagement.Entity;
namespace StockManagement.Interface
{
    public interface IDailyMaterialInfoRepository
    {
        DMRMaster? GetById(int id);
        IEnumerable<DMRMaster> GetAll();
        void Add(DMRMaster entity);
        void Update(DMRMaster entity);
        void Delete(int id);
    }
    public interface IDailyMaterialDetailRepository
    {
        DailyMaterialDetail? GetById(int id);
        IEnumerable<DailyMaterialDetail> GetByDmrId(int dmrId);
        void Add(DailyMaterialDetail entity);
        void Update(DailyMaterialDetail entity);
        void Delete(int id);
    }
}
