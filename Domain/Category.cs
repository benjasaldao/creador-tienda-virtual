using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Category
    {
        public int id {  get; set; }
        public string description { get; set; }
        public string imageUrl { get; set; }
        public int storeId { get; set; }
        public bool state { get; set; }
    }
}
