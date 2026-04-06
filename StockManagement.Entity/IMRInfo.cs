using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Entity
{
    /// <summary>
    ///  Used on the website to confirm quality of delivered goods.
    /// Ensures items meet standards before approval.
    ///  Represents inspection details for received materials.
    /// Ensures quality check before final acceptance.
    /// </summary>
    public class IMRInfo
    {
        public int ImrId { get; set; }
        public int ProductId {  get; set; }
        public string InspectedBy {  get; set; }
        public DateTime InspectedDate { get; set; }
        public string InspectStatus {  get; set; }
        public string Remarks {  get; set; }
    }
}
