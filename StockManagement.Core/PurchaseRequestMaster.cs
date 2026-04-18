using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Core
{
   public class PurchaseRequestMaster
    {
        public int PRId { get; set; }         
        public string PRNumber { get; set; }            
        public DateTime RequestDate { get; set; }   
        public string RequestedBy { get; set; }      
        public string Department { get; set; }     
        public string Status { get; set; }             
        public string Remarks { get; set; }             
        public DateTime CreatedDate { get; set; }    
        public DateTime ModifiedDate { get; set; }      

        public float TotalAmount { get; set; }           
        
        public List<PurchaseRequestDetails> Items { get; set; } = new List<PurchaseRequestDetails>();
    }
}
