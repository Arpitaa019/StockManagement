using StockManagement.Entity;
using StockManagement.Interface;

namespace StockManagement.Service
{
    public class IMRCumulativeService : IIMRCumulativeService
    {
        private readonly IIMRCumulativeRepository _repo;
        public IMRCumulativeService(IIMRCumulativeRepository repo) { _repo = repo; }
        public IMRCumulative? Get(int id) => _repo.GetById(id);
        public IEnumerable<IMRCumulative> GetAll() => _repo.GetAll();
        public void Create(IMRCumulative entity) => _repo.Add(entity);
        public void Update(IMRCumulative entity) => _repo.Update(entity);
        public void Delete(int id) => _repo.Delete(id);
    }
}
