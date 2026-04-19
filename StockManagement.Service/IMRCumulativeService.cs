using StockManagement.Entity;
using StockManagement.Interface;

namespace StockManagement.Service
{
    public class IMIRCumulativeService : IIMIRCumulativeService
    {
        private readonly IIMIRCumulativeRepository _repo;
        public IMIRCumulativeService(IIMIRCumulativeRepository repo) { _repo = repo; }
        public IMIRCumulative? Get(int id) => _repo.GetById(id);
        public IEnumerable<IMIRCumulative> GetAll() => _repo.GetAll();
        public void Create(IMIRCumulative entity) => _repo.Add(entity);
        public void Update(IMIRCumulative entity) => _repo.Update(entity);
        public void Delete(int id) => _repo.Delete(id);
    }
}
