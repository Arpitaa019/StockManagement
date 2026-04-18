using StockManagement.Core;

namespace StockManagement.Interface
{
    public interface IPurchaseOrderService
    {
        PurchaseOrderMaster? Get(int id);
        IEnumerable<PurchaseOrderMaster> GetAll();
        void Create(PurchaseOrderMaster entity);
        void Update(PurchaseOrderMaster entity);
        void Delete(int id);
    }
}
