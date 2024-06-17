using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Order
    {
        public int id { get; set; }
        public int storeUserId { get; set; }
        public int storeId { get; set; }
        public int amount { get; set; }
        public string comment { get; set; }
        public bool paid { get; set; }
        public bool canceled { get; set; }
    }
}
