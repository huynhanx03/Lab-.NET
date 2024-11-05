using BusinessObject;
using BusinessObject.RequestBody.OrderRequestBody;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository 
{
    public class OrderDetailRepository : IRepositoryOrderDetail
    {
        private readonly EStoreAPContext _context;
        public OrderDetailRepository(EStoreAPContext context)
        {
            _context = context;
        }

        public Task<bool> Add(OrderDetail id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(Guid id)
        {
            var orderDetail = await _context.OrderDetails.Where(x => x.OrderId == id).FirstOrDefaultAsync();
            if (orderDetail != null)
            {
                _context.OrderDetails.Remove(orderDetail);
                return true;
            }
            return false;
        }

        public async Task<OrderDetail> GetById(Guid id)
        {
            var orderDetail = await _context.OrderDetails.Where(x => x.OrderId == id).FirstOrDefaultAsync();
            if (orderDetail != null)
            {
                return orderDetail;
            }
            return null;
        }

        public async Task<IEnumerable<OrderDetail>> GetList()
        {
            var orderDetails = await _context.OrderDetails.ToListAsync();
            if (orderDetails.Count > 0)
            {
                return orderDetails;
            }
            return new List<OrderDetail>();
        }
        public async Task<bool> Update(OrderDetail newValue)
        {
            _context.OrderDetails.Update(newValue);
            bool result = await _context.SaveChangesAsync() > 0;
            return await Task.FromResult(result);
        }
    }
}
