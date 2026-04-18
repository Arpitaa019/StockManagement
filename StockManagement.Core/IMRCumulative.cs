using System;

namespace StockManagement.Entity
{
    public class IMRCumulative
    {
        public int ImrCumulativeId { get; set; }
        public int ImrId { get; set; }
        public decimal Quantity { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
