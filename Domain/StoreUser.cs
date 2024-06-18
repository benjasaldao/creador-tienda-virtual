using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// User that is created in a created store
    /// </summary>
    public class StoreUser : User
    {
        public string adress { get; set; }
        public string city { get; set; }
        public int storeId { get; set; }
        public bool state { get; set; }
    }
}
