using System;

namespace StockManagement.Entity
{
    // Renamed to reflect correct acronym: IMIR (Imir Master/Records)
    public class IMIRCumulative
    {
        public int ImirCumulativeId { get; set; }
        public int ImirId { get; set; }
        public decimal Quantity { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
