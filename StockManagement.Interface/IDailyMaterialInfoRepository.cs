using StockManagement.Entity;
namespace StockManagement.Interface
{
    public interface IDailyMaterialInfoRepository
    {
        DailyMaterialInfo? GetById(int id);
        IEnumerable<DailyMaterialInfo> GetAll();
        void Add(DailyMaterialInfo entity);
        void Update(DailyMaterialInfo entity);
        void Delete(int id);
    }
    public interface IDailyMaterialInfoService
    {
        DailyMaterialInfo? Get(int id);
        IEnumerable<DailyMaterialInfo> GetAll();
        void Create(DailyMaterialInfo entity);
        void Update(DailyMaterialInfo entity);
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
    public interface IDailyMaterialDetailService
    {
        DailyMaterialDetail? Get(int id);
        IEnumerable<DailyMaterialDetail> GetByDmrId(int dmrId);
        void Create(DailyMaterialDetail entity);
        void Update(DailyMaterialDetail entity);
        void Delete(int id);
    }
}
