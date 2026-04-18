using StockManagement.Entity;
namespace StockManagement.Interface
{
    public interface IInvoiceInfoRepository
    {
        InvoiceMaster? GetById(int id);
        IEnumerable<InvoiceMaster> GetAll();
        void Add(InvoiceMaster entity);
        void Update(InvoiceMaster entity);
        void Delete(int id);
    }
}
