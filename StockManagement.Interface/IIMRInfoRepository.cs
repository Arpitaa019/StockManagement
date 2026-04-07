using StockManagement.Entity;
namespace StockManagement.Interface
{
    public interface IIMRInfoRepository
    {
        IMRInfo? GetById(int id);
        IEnumerable<IMRInfo> GetAll();
        void Add(IMRInfo entity);
        void Update(IMRInfo entity);
        void Delete(int id);
    }
    public interface IIMRInfoService
    {
        IMRInfo? Get(int id);
        IEnumerable<IMRInfo> GetAll();
        void Create(IMRInfo entity);
        void Update(IMRInfo entity);
        void Delete(int id);
    }
}
