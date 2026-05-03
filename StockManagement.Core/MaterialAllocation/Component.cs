namespace StockManagement.Core
{
    public class Component
    {
        public int ComponentId { get; set; }
        public int SpoolId { get; set; }

        // Optional grouping and classification
        public int? ComponentGroupId { get; set; }
        public int? ComponentClassId { get; set; }

        public string ItemCodeNo { get; set; } = string.Empty;   // link to Sapcode.ItemCodeNo
        public string PartNumber { get; set; } = string.Empty;   // vendor part number or internal part number
        public string? Description { get; set; }

        public decimal Quantity { get; set; } = 1;
        public string? UnitOfMeasure { get; set; }

        // Navigation helpers (not required for simple DTOs)
        public ComponentGroup? ComponentGroup { get; set; }
        public ComponentClass? ComponentClass { get; set; }
    }
}
