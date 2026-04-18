using StockManagement.Entity;
namespace StockManagement.Interface
{
    public interface IAdminInfoService
    {
        AdminInfo? Get(int id);
        IEnumerable<AdminInfo> GetAll();
        void Create(AdminInfo entity);
        void Update(AdminInfo entity);
        void Delete(int id);
    }
}
