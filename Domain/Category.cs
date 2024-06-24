using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Category
    { 

        public Category() { }
        /// <summary>
        /// Constructor created to be used within the product object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        public Category(int _id, string _description) 
        {
            id = _id;
            description = _description;
        }
        public int id {  get; set; }
        public string description { get; set; }
        public string imageUrl { get; set; }
        public int storeId { get; set; }
        public bool state { get; set; }
    }
}
