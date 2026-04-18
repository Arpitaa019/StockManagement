using StockManagement.Core;
namespace StockManagement.Interface
{
    public interface IPurchaseRequestRepository
    {
        PurchaseRequestMaster? GetById(int id);
        IEnumerable<PurchaseRequestMaster> GetAll();
        void Add(PurchaseRequestMaster entity);
        void Update(PurchaseRequestMaster entity);
        void Delete(int id);
    }
}
