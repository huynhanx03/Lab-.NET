using BusinessObject.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void AddOrder(Order o) => OrderDAO.Instance.InsertOrder(o);

        public void DeleteOrder(Order o) => OrderDAO.Instance.DeleteOrder(o);

        public Order GetOrderByID(int id) => OrderDAO.Instance.FindOrderById(id);

        public IEnumerable<Order> GetOrders() => OrderDAO.Instance.GetOrders();

        public void UpdateOrder(Order o) => OrderDAO.Instance.UpdateOrder(o);
    }
}
