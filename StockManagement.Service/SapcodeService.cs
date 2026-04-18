using StockManagement.Core;
using StockManagement.Interface;

namespace StockManagement.Service
{
    public class SapcodeService : ISapcodeService
    {
        private readonly ISapcodeRepository _repo;
        public SapcodeService(ISapcodeRepository repo) { _repo = repo; }
        public Sapcode? Get(int id) => _repo.GetById(id);
        public IEnumerable<Sapcode> GetAll() => _repo.GetAll();
        public void Create(Sapcode entity) => _repo.Add(entity);
        public void Update(Sapcode entity) => _repo.Update(entity);
        public void Delete(int id) => _repo.Delete(id);
    }
}
