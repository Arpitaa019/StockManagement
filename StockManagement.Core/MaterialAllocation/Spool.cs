using System.Collections.Generic;

namespace StockManagement.Core
{
    public class Spool
    {
        public int SpoolId { get; set; }
        public int LineId { get; set; }
        public string SpoolNumber { get; set; } = string.Empty; // unique identifier / tag for the spool
        public string? Description { get; set; }
        public int? ReferenceId { get; set; }
        public string? ReferenceType { get; set; }

        // Components that make up this spool
        public List<Component> Components { get; set; } = new List<Component>();

        // Joints that belong to this spool
        public List<Joint> Joints { get; set; } = new List<Joint>();
    }
}
