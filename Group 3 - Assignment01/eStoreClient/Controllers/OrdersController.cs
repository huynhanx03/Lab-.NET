using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using System.Net.Http.Headers;

namespace eStoreClient.Controllers
{
    public class OrdersController : Controller
    {
        private readonly HttpClient client = null;
        private string OrderApiUrl = "";
        private readonly FStoreDBContext _context;
          
        public OrdersController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            OrderApiUrl = "https://localhost:7211/api/Orders";
        }

        public async Task<List<Order>> getOrders()
        {
            HttpResponseMessage response = await client.GetAsync(OrderApiUrl + "/GetOrders");
            List<Order>? orders = new List<Order>();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                orders = response.Content.ReadFromJsonAsync<List<Order>>().Result;
            }

            return orders;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await getOrders());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HttpResponseMessage response = await client.GetAsync(OrderApiUrl + "/GetOrderByID/" + id);

            Order order = new Order();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                order = response.Content.ReadFromJsonAsync<Order>().Result;
            }

            return View(order);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await client.DeleteAsync(OrderApiUrl + "/DeleteOrder/" + id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Statistics(DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null || endDate == null)
            {
                // Default to last 30 days if no dates provided
                startDate = DateTime.Now.AddDays(-30);
                endDate = DateTime.Now;
            }

            var orders = await getOrders();

            var salesReport = orders
                .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                .GroupBy(o => o.OrderDate.Date) // Nhóm theo ngày của OrderDate
                .Select(g => new SalesReportModel
                {
                    OrderDate = g.Key, // Ngày của nhóm
                    TotalSales = g.Sum(o => o.OrderDetails.Sum(od => od.Quantity * od.UnitPrice)) // Tính tổng doanh số cho nhóm
                })
                .OrderByDescending(r => r.TotalSales) // Sắp xếp theo tổng doanh số giảm dần
                .ToList();

            return View(salesReport);
        }
    }
}
