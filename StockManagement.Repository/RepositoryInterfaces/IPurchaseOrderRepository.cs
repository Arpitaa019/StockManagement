using StockManagement.Core;

namespace StockManagement.Interface
{
    public interface IPurchaseOrderRepository
    {
        PurchaseOrderMaster? GetById(int id);
        IEnumerable<PurchaseOrderMaster> GetAll();
        void Add(PurchaseOrderMaster entity);
        void Update(PurchaseOrderMaster entity);
        void Delete(int id);
    }
}
