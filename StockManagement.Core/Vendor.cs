using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Core
{
    public class Vendor
    {
        public int VendorId { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string GSTNumber { get; set; }   // For India-specific tax compliance
        public string PANNumber { get; set; }   // Permanent Account Number (India)
        public string BankAccount { get; set; }
        public string IFSCCode { get; set; }    // Bank branch identifier
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string VendorType { get; set; }  // e.g., Manufacturer, Supplier, Contractor
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

}
