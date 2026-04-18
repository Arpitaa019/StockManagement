using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Entity
{
    /// <summary>
    /// Request For Proposal, Represents a Request for Proposal created by a user.
    ///Information Product and required quantity details
    /// </summary>
    public class RFPInfo
    {
        public int RfpId {  get; set; }
        public string ProductList {  get; set; }
        public string CreatedBy {  get; set; }
        public DateTime Created {  get; set; } 
    }
}
