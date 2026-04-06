using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Entity
{
    /// <summary>
    /// - Internal approval step before finalizing purchase.
   ///Ensures managers check before buying.

    /// </summary>
    public class RequestForApprovalInfo
    {
        public int RequestId { get; set; }         
        public int RfpId { get; set; }              // Link to Request for Proposal
        public int ProductId { get; set; }          // Product under approval
        public int RequestedBy { get; set; }        // User who raised request
        public DateTime RequestedDate { get; set; } // When request was created

        public bool IsApproved { get; set; }        // First-level approval status
        public int? ApprovedBy { get; set; }        // Admin/User who approved
        public DateTime? ApprovedDate { get; set; } // Approval timestamp

        public bool IsFinalApproved { get; set; }   // Final approval status
        public int? FinalApprovedBy { get; set; }   // Admin/User who finalized
        public DateTime? FinalApprovedDate { get; set; } // Final approval timestamp

        public string Remarks { get; set; }         // Optional comments
        public string Status { get; set; }     // Pending, Approved, Reject
    }
}