using StockManagement.Entity;
namespace StockManagement.Interface
{
    public interface IRFPInfoRepository
    {
        RFPInfo? GetById(int id);
        IEnumerable<RFPInfo> GetAll();
        void Add(RFPInfo entity);
        void Update(RFPInfo entity);
        void Delete(int id);
    }
    public interface IRFPInfoService
    {
        RFPInfo? Get(int id);
        IEnumerable<RFPInfo> GetAll();
        void Create(RFPInfo entity);
        void Update(RFPInfo entity);
        void Delete(int id);
    }
}
