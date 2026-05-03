using System.Collections.Generic;

namespace StockManagement.Core
{
    public class ComponentGroup
    {
        public int ComponentGroupId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        

        // Components in this group
        public List<Component> Components { get; set; } = new List<Component>();
    }
}
