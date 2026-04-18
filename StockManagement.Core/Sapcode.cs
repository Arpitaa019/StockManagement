using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockManagement.Core
{
    public class Sapcode
    {
        public int ItemCodeDescriptionMasterId { get; set; }
        public string ItemCodeNo { get; set; }
        public string ItemType { get; set; }
        public string Material { get; set; }
        public string SizeInch { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }
        public float RequiredQty { get; set; }
        public float AllocatedQty { get; set; }
        public float IssuedQty { get; set; }

        // 🔑 Suggested additional properties
        public string UnitOfMeasure { get; set; }        // e.g., KG, MTR, PCS
        public string BatchNo { get; set; }              // For material traceability
        public string HeatNo { get; set; }               // Metallurgical tracking
        public string VendorName { get; set; }           // Supplier reference
        public DateTime AllocationDate { get; set; }     // When allocation was made
        public DateTime? IssueDate { get; set; }         // When issued to site
        public string Location { get; set; }             // Warehouse/yard reference
        public bool IsActive { get; set; }               // Soft delete / status flag
        public string Remarks { get; set; }              // Free-text notes
        public DateTime CreatedDate { get; set; }        // Audit trail
        public DateTime ModifiedDate { get; set; }       // Audit trail
    }

}
