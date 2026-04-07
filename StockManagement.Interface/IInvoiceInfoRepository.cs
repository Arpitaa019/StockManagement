using StockManagement.Entity;
namespace StockManagement.Interface
{
    public interface IInvoiceInfoRepository
    {
        InvoiceInfo? GetById(int id);
        IEnumerable<InvoiceInfo> GetAll();
        void Add(InvoiceInfo entity);
        void Update(InvoiceInfo entity);
        void Delete(int id);
    }
    public interface IInvoiceInfoService
    {
        InvoiceInfo? Get(int id);
        IEnumerable<InvoiceInfo> GetAll();
        void Create(InvoiceInfo entity);
        void Update(InvoiceInfo entity);
        void Delete(int id);
    }
}
