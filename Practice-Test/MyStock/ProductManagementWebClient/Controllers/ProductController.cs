using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ProductManagementWebClient.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient client = null;
        private string ProductApiUrl = "";
        private static List<Product> _listProducts = new List<Product>();
        private static List<Category> _listCategories = new List<Category>();

        public ProductController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ProductApiUrl = "https://localhost:7283/api/Products";
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
            _listProducts = listProducts;
            return View(listProducts);
        }

        public async Task<IActionResult> Create()
        {
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl + "/Categories");
            string strData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            List<Category> listCategories = JsonSerializer.Deserialize<List<Category>>(strData, options);
            _listCategories = listCategories;

            // Populate the ViewBag with the list of categories
            ViewBag.CategoryId = new SelectList(_listCategories, "CategoryId", "CategoryName");

            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            Product product = _listProducts.FirstOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            HttpResponseMessage response = await client.GetAsync(ProductApiUrl + "/Categories");
            string strData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            List<Category> listCategories = JsonSerializer.Deserialize<List<Category>>(strData, options);
            _listCategories = listCategories;

            // Populate the ViewBag with the list of categories
            ViewBag.CategoryId = new SelectList(_listCategories, "CategoryId", "CategoryName");

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Product p)
        {
            using (var respone = await client.PostAsJsonAsync(ProductApiUrl, p))
            {
                string apiResponse = await respone.Content.ReadAsStringAsync();
            }

            return Redirect("/Product/Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromForm] Product p)
        {
            using (var respone = await client.PutAsJsonAsync(ProductApiUrl + "/" + id, p))
            {
                string apiResponse = await respone.Content.ReadAsStringAsync();
            }

            return Redirect("/Product/Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            Product product = _listProducts.FirstOrDefault(p => p.ProductId == id);
            
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Product product = _listProducts.FirstOrDefault(p => p.ProductId == id);
            
            if (product == null)
            {
                return NotFound();
            }
            
            await client.DeleteAsync(ProductApiUrl + "/" + id);
            return Redirect("/Product/Index");
        }
    }
}
