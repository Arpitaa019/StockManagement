using StockManagement.Entity;
namespace StockManagement.Interface
{
    public interface IRFQInfoRepository
    {
        RFQInfo? GetById(int id);
        IEnumerable<RFQInfo> GetAll();
        void Add(RFQInfo entity);
        void Update(RFQInfo entity);
        void Delete(int id);
    }
}
