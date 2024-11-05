using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject 
{ 
    public class ProductDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public int UnitStock { get; set; }
        public string CategoryName { get; set; }
    }
    public class ProductAddDto
    {
        public string ProductName { get; set;}
        public string CategoryId { get; set;}
        public int UnitPrice { get; set;}
        public int UnitStock { get; set;}
    }
}
