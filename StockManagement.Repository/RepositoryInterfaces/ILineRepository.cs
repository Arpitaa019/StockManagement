using StockManagement.Core;
using System.Collections.Generic;

namespace StockManagement.Interface
{
    public interface ILineRepository
    {
        IEnumerable<Line> GetAllLines();
        Line? GetLineById(int id);
    }
}
