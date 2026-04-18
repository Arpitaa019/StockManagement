using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Entity
{
    /// <summary>
    ///    after creation login will be done by this user and rest of the action will be performed
    /// </summary>
    public class User
    {
        public int UserId {  get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role {  get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
