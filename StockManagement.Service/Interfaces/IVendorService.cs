using StockManagement.Core;
namespace StockManagement.Interface
{
    public interface IVendorService
    {
        Vendor? Get(int id);
        IEnumerable<Vendor> GetAll();
        void Create(Vendor entity);
        void Update(Vendor entity);
        void Delete(int id);
    }
}
