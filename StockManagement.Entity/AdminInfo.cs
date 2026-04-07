using System;
using System.Collections.Generic;
using System.Linq;

namespace StockManagement.Entity
{


    public class AdminInfo
    {
        public int AdminId { get; set; }
        public string Name { get; set; }
       public string Password {  get; set; } 
       public string Email {  get; set; }
        public DateTime Created { get; set; }
    }
}
