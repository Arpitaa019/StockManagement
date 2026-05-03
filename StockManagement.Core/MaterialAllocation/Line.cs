using System.Collections.Generic;

namespace StockManagement.Core
{
    public class Line
    {
        public int LineId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        // Spools that belong to this line
        public List<Spool> Spools { get; set; } = new List<Spool>();
    }
}
