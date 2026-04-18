using StockManagement.Entity;
namespace StockManagement.Interface
{
    public interface IDailyMaterialInfoService
    {
        DailyMaterialInfo? Get(int id);
        IEnumerable<DailyMaterialInfo> GetAll();
        void Create(DailyMaterialInfo entity);
        void Update(DailyMaterialInfo entity);
        void Delete(int id);
    }
   
}
