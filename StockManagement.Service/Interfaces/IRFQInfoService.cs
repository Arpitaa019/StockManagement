using StockManagement.Entity;

namespace StockManagement.Interface
{
    public interface IRFQInfoService
    {
        RFQInfo? Get(int id);
        IEnumerable<RFQInfo> GetAll();
        void Create(RFQInfo entity);
        void Update(RFQInfo entity);
        void Delete(int id);
    }
}
