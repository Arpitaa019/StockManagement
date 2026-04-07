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
    public interface IRFQInfoService
    {
        RFQInfo? Get(int id);
        IEnumerable<RFQInfo> GetAll();
        void Create(RFQInfo entity);
        void Update(RFQInfo entity);
        void Delete(int id);
    }
}
