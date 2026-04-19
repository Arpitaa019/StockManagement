using StockManagement.Entity;

namespace StockManagement.Services.Interfaces
{
    public interface IDailyMaterialDetailService
    {
        DmrDetails? Get(int id);
        IEnumerable<DmrDetails> GetByDmrId(int dmrId);
        void Create(DmrDetails entity);
        void Update(DmrDetails entity);
        void Delete(int id);
    }
}
