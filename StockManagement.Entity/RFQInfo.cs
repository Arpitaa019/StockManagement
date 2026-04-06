using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Entity
{
    /// <summary>
    /// - Vendors reply with prices.
   ///- Properties: ProductList, IsApproved, ApprovedBy, IsFinalApproved, FinalApprovedBy.
    /// </summary>
    public class RFQInfo
    {
        public int RfqId {  get; set; }
        public string ProductList {  get; set; }
        public bool IsApproved {  get; set; }
        public string ApprovedBy {  get; set; }
        public bool IsFinalApproved {  get; set; }
        public string FinalApprovedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
