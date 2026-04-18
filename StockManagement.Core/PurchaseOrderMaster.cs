using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Core
{
    public class PurchaseOrderMaster
    {
        public int POId { get; set; }
        public string PONumber { get; set; }
        public int PRId { get; set; }                   // Reference to PurchaseRequestMaster
        public string PRNumber { get; set; }            // Denormalized for display
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Department { get; set; }
        public string Status { get; set; }              // e.g., Draft, Issued, Closed, Cancelled
        public float TotalAmount { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public List<PurchaseOrderDetails> Items { get; set; } = new List<PurchaseOrderDetails>();
    }
}
