using System.Collections.Generic;

namespace StockManagement.Core
{
    public class ComponentClass
    {
        public int ComponentClassId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public List<Component> Components { get; set; } = new List<Component>();
    }
}
