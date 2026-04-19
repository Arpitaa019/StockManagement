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
        DmrDetails? GetById(int id);
        IEnumerable<DmrDetails> GetByDmrId(int dmrId);
        void Add(DmrDetails entity);
        void Update(DmrDetails entity);
        void Delete(int id);
    }
}
