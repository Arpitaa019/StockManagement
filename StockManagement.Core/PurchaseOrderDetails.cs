using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Core
{
    public class PurchaseOrderDetails
    {
        public int PODetailId { get; set; }             // Primary key
        public int PurchaseOrderMasterId { get; set; }  // Foreign key to PurchaseOrderMaster
        public string ItemCodeNo { get; set; }          // Link to Sapcode.ItemCodeNo
        public string Description { get; set; }         // Item description
        public float Quantity { get; set; }             // Ordered quantity
        public string UnitOfMeasure { get; set; }       // e.g., MTR, PCS
        public float UnitPrice { get; set; }            // Price per unit
        public float TotalPrice { get; set; }           // Quantity * UnitPrice
    }
}
