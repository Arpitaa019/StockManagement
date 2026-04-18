using System;
using System.Collections.Generic;

namespace StockManagement.Core
{
    public class PurchaseRequestDetails
    {
        public int PRDetailId { get; set; }             // Primary key
        public int PurchaseRequestMasterId { get; set; }                   // Foreign key to PurchaseRequestMaster
        public string ItemCodeNo { get; set; }          // Link to Sapcode.ItemCodeNo
        public string Description { get; set; }         // Item description
        public float Quantity { get; set; }             // Requested quantity
        public string UnitOfMeasure { get; set; }       // e.g., MTR, PCS
    }
}