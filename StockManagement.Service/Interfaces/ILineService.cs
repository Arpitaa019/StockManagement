using StockManagement.Core;
using System.Collections.Generic;

namespace StockManagement.Interface
{
    public interface ILineService
    {
        IEnumerable<Line> GetAll();
        Line? Get(int id);
    }
}
