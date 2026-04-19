using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Entity
{
    public class DmrDetails
    {
        public int DmrDetailId { get; set; }
        public int DmrId { get; set; }               // Linked to DMR Master
        public int ProductId { get; set; }           // Product delivered
        public int Quantity { get; set; }            // Quantity received
        public string Status { get; set; }
    }
}
