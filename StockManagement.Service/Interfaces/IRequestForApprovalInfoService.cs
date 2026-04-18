using StockManagement.Entity;
namespace StockManagement.Interface
{
    public interface IRequestForApprovalInfoService
    {
        RequestForApprovalInfo? Get(int id);
        IEnumerable<RequestForApprovalInfo> GetAll();
        void Create(RequestForApprovalInfo entity);
        void Update(RequestForApprovalInfo entity);
        void Delete(int id);
    }
}
