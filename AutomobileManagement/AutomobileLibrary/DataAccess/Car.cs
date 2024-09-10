using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.DataAccess
{
    public class Car
    {
        public int CarID { get; set; } // Cột CarID
        public string CarName { get; set; } // Cột CarName
        public string Manufacturer { get; set; } // Cột Manufacturer
        public decimal Price { get; set; } // Cột Price
        public int ReleasedYear { get; set; } // Cột ReleasedYear
    }

}
