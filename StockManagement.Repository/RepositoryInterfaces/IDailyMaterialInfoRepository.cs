using StockManagement.Entity;
namespace StockManagement.Interface
{
    // Repository for DMR (Delivery Material Report) master records
    public interface IDMRRepository
    {
        DMRMaster? GetById(int id);
        IEnumerable<DMRMaster> GetAll();
        void Add(DMRMaster entity);
        void Update(DMRMaster entity);
        void Delete(int id);
    }

    // Repository for DMR detail records
    public interface IDMRDetailRepository
    {
        DmrDetails? GetById(int id);
        IEnumerable<DmrDetails> GetByDmrId(int dmrId);
        void Add(DmrDetails entity);
        void Update(DmrDetails entity);
        void Delete(int id);
    }
}
