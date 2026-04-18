using StockManagement.Entity;
namespace StockManagement.Interface
{
    public interface IAdminInfoRepository
    {
        AdminInfo? GetById(int id);
        IEnumerable<AdminInfo> GetAll();
        void Add(AdminInfo entity);
        void Update(AdminInfo entity);
        void Delete(int id);
    }
}
