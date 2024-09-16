using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ProductManagementWebClient.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient client = null;
        private string ProductApiUrl = "";

        public ProductController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ProductApiUrl = "http://localhost:53633/api/products";
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl);
            string strData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<Product> listProducts = JsonSerializer.Deserialize<List<Product>>(strData, options);
            return View(listProducts);
        }

        public ActionResult Details(int id)
        {
            // Chi tiết logic lấy thông tin sản phẩm theo ID sẽ được thêm vào đây
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product p)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(ProductApiUrl, p);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }

        public ActionResult Edit(int id)
        {
            // Chi tiết logic cập nhật sản phẩm sẽ được thêm vào đây
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            // Chi tiết logic cập nhật sản phẩm sau POST sẽ được thêm vào đây
            return View();
        }

        public ActionResult Delete(int id)
        {
            // Chi tiết logic xóa sản phẩm sẽ được thêm vào đây
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            // Chi tiết logic xử lý sau khi xóa sản phẩm sẽ được thêm vào đây
            return View();
        }
    }
}
