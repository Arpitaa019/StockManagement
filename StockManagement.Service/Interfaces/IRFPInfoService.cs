using StockManagement.Entity;
namespace StockManagement.Interface
{
    public interface IRFPInfoService
    {
        RFPInfo? Get(int id);
        IEnumerable<RFPInfo> GetAll();
        void Create(RFPInfo entity);
        void Update(RFPInfo entity);
        void Delete(int id);
    }
}
