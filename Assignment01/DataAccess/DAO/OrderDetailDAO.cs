using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class OrderDetailDAO
    {
        public List<OrderDetail> GetOrderDetails()
        {
            var ListOrderDetails = new List<OrderDetail>();
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    ListOrderDetails = context.OrderDetails.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return ListOrderDetails;
        }

    }
}
