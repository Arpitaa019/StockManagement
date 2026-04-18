using StockManagement.Entity;
namespace StockManagement.Interface
{
    public interface IInvoiceInfoService
    {
        InvoiceMaster? Get(int id);
        IEnumerable<InvoiceMaster> GetAll();
        void Create(InvoiceMaster entity);
        void Update(InvoiceMaster entity);
        void Delete(int id);
    }
}
