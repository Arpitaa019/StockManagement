using StockManagement.Core;
using StockManagement.Interface;
using System.Collections.Generic;

namespace StockManagement.Service
{
    public class LineService : ILineService
    {
        private readonly ILineRepository _repo;
        public LineService(ILineRepository repo) { _repo = repo; }
        public IEnumerable<Line> GetAll() => _repo.GetAllLines();
        public Line? Get(int id) => _repo.GetLineById(id);
    }
}
