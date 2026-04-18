using StockManagement.Core;
namespace StockManagement.Interface
{
    public interface IVendorRepository
    {
        Vendor? GetById(int id);
        IEnumerable<Vendor> GetAll();
        void Add(Vendor entity);
        void Update(Vendor entity);
        void Delete(int id);
    }
}
