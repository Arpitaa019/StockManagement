using StockManagement.Core;
namespace StockManagement.Interface
{
    public interface IPurchaseRequestService
    {
        PurchaseRequestMaster? Get(int id);
        IEnumerable<PurchaseRequestMaster> GetAll();
        void Create(PurchaseRequestMaster entity);
        void Update(PurchaseRequestMaster entity);
        void Delete(int id);
    }
}
