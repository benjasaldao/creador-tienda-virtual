using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Category category { get; set; }
        public int price { get; set; }
        public string unit {  get; set; }
        public int storeId {  get; set; }
        public int stock {  get; set; }
        public bool state { get; set; }
    }
}
