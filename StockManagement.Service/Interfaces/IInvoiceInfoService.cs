using StockManagement.Entity;
namespace StockManagement.Interface
{
    public interface IInvoiceInfoService
    {
        InvoiceInfo? Get(int id);
        IEnumerable<InvoiceInfo> GetAll();
        void Create(InvoiceInfo entity);
        void Update(InvoiceInfo entity);
        void Delete(int id);
    }
}
