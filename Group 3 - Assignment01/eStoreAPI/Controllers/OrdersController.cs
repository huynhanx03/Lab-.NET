using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderRepository repository = new OrderRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            var orders = repository.GetOrders(); // Lấy danh sách đơn hàng từ repository

            if (orders == null || !orders.Any())
            {
                return NotFound(); // Trả về 404 nếu không có đơn hàng
            }

            return Ok(orders); // Trả về 200 OK với danh sách đơn hàng
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrderByID(int id) => repository.GetOrderByID(id);

        [HttpPost]
        public IActionResult PostOrder([FromBody] Order o)
        {
            repository.AddOrder(o);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var o = repository.GetOrderByID(id);
            if (o == null)
            {
                return NotFound();
            }
            repository.DeleteOrder(o);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] Order o)
        {
            var tmp = repository.GetOrderByID(id);
            if (tmp == null)
            {
                return NotFound();
            }
            repository.UpdateOrder(o);
            return NoContent();
        }
    }
}
