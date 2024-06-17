using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ProductImage
    {
        public int id {  get; set; }
        public string alt {  get; set; }
        public string imageUrl { get; set; }
        public int productId { get; set; }
    }
}
