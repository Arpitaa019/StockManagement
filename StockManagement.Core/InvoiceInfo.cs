using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace StockManagement.Entity
{
    /// <summary>
    ///  Created after goods are received.
    /// // Contains product details, vendor info, and payment terms.
    /// Represents invoice generated after DMR finalization.
    /// </summary>
    public class InvoiceInfo
    {
        public int InvoiceId { get; set; }
        public int DmrId {  get; set; }
        public int VendorId {  get; set; }
        public int TotalAmount {  get; set; }
        public DateTime InvoiceDate {  get; set; }
        public string CreatedBy {  get; set; }
        public string Status {  get; set; }
    }
}
