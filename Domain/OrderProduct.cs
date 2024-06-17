using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderProduct
    {
        public int id {  get; set; }
        public int orderId { get; set; }
        public int productId { get; set; }
        public int storeId { get; set; }
        public int amount { get; set; }
    }
}
