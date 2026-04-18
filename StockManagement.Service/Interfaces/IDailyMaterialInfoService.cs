using StockManagement.Entity;
namespace StockManagement.Interface
{
    public interface IDailyMaterialInfoService
    {
        DMRMaster? Get(int id);
        IEnumerable<DMRMaster> GetAll();
        void Create(DMRMaster entity);
        void Update(DMRMaster entity);
        void Delete(int id);
    }
   
}
