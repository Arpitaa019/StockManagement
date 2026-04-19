using System;
using System.Collections.Generic;

namespace StockManagement.Entity
{
  /// <summary>
     /// DMR (Delivery Material Report)
     /// Master + Detail records when goods arrive.
     /// Automatic process: once delivery is confirmed, system generates DMR.
      /// Properties: ApprovedBy, IsFinalize.
  /// </summary>
    public class DMRMaster
    {
        public int DmrId { get; set; }               // Unique identifier
        public int? POId { get; set; }               // Reference to Purchase Order (optional)
        public string? PONumber { get; set; }        // Denormalized PO number for display
        public int VendorId { get; set; }            // Vendor delivering goods
        public DateTime DeliveryDate { get; set; }   // Date of delivery
        public string ApprovedBy { get; set; }       // Admin/User who approved
        public bool IsFinalized { get; set; }        // Finalization status
        public DateTime? FinalizedDate { get; set; } // When finalized
        public string Remarks { get; set; }
    }

  
}
