using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Entity
{

    /// <summary>
    /// self master (super admin login)
    /// self information
      /// all permissions to execute or perform any action
    /// </summary>
    public class AdminInfo
    {
        public int AdminId { get; set; }
        public string Name { get; set; }
       public string Password {  get; set; } 
       public string Email {  get; set; }
        public DateTime Created { get; set; }
    }
}
