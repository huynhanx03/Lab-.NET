using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IRepositoryOrder
    {
        private readonly EStoreAPContext _context;
        public OrderRepository(EStoreAPContext context)
        {
            _context = context;
        }

        public Task<bool> Add(Order id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(Guid id)
        {
            var order = await _context.Orders.Where(x => x.OrderId == id).FirstOrDefaultAsync();
            if (order != null)
            {
                _context.Orders.Remove(order);
                return true;
            }
            return false;
        }

        public async Task<Order> GetById(Guid id)
        {
            var order = await _context.Orders.Where(x => x.OrderId == id).FirstOrDefaultAsync();
            if (order != null)
            {
                return order;
            }
            return null;
        }

        public async Task<IEnumerable<Order>> GetList()
        {
            var order = await _context.Orders.ToListAsync();
            if (order.Count > 0)
            {
                return order;
            }
            return new List<Order>();
        }

        public async Task<bool> Update(Order newValue)
        {
            _context.Orders.Update(newValue);
            bool result = await _context.SaveChangesAsync() > 0;
            return await Task.FromResult(result);
        }
    }
}
