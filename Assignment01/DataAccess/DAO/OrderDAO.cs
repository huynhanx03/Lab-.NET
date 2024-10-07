using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class OrderDAO
    {
        //Using Singleton Pattern
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new Object();
        private OrderDAO() { }

        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                }
                return instance;
            }
        }
        public IEnumerable<Order> GetOrders()
        {
            List<Order> orders;
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    orders = context.Orders.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orders;
        }

        public Order FindOrderById(int oId)
        {
            Order o = new Order();
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    o = context.Orders.SingleOrDefault(x => x.OrderId == oId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return o;
        }

        public void InsertOrder(Order o)
        {
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    context.Orders.Add(o);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateOrder(Order o)
        {
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    context.Entry<Order>(o).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteOrder(Order o)
        {
            try
            {
                using (var context = new PRN231_AS1Context())
                {
                    var o1 = context.Orders.SingleOrDefault(c => c.OrderId == o.OrderId);
                    context.Orders.Remove(o1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
