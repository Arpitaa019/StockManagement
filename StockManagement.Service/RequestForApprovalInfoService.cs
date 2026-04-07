using StockManagement.Entity;
using StockManagement.Interface;

namespace StockManagement.Service
{
    public class RequestForApprovalInfoService : IRequestForApprovalInfoService
    {
        private readonly IRequestForApprovalInfoRepository _repo;
        public RequestForApprovalInfoService(IRequestForApprovalInfoRepository repo) { _repo = repo; }
        public RequestForApprovalInfo? Get(int id) => _repo.GetById(id);
        public IEnumerable<RequestForApprovalInfo> GetAll() => _repo.GetAll();
        public void Create(RequestForApprovalInfo entity) => _repo.Add(entity);
        public void Update(RequestForApprovalInfo entity) => _repo.Update(entity);
        public void Delete(int id) => _repo.Delete(id);
    }
}