using StockManagement.Entity;
namespace StockManagement.Interface
{
    public interface IRequestForApprovalInfoRepository
    {
        RequestForApprovalInfo? GetById(int id);
        IEnumerable<RequestForApprovalInfo> GetAll();
        void Add(RequestForApprovalInfo entity);
        void Update(RequestForApprovalInfo entity);
        void Delete(int id);
    }
    public interface IRequestForApprovalInfoService
    {
        RequestForApprovalInfo? Get(int id);
        IEnumerable<RequestForApprovalInfo> GetAll();
        void Create(RequestForApprovalInfo entity);
        void Update(RequestForApprovalInfo entity);
        void Delete(int id);
    }
}
