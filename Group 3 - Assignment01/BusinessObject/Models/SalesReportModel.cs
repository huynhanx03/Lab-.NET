using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class SalesReportModel
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalSales { get; set; }
    }
}
