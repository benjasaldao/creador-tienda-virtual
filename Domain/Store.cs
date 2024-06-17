using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Store
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int userId { get; set; }
        public bool state {  get; set; }
    }
}
