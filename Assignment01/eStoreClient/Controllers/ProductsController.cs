using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace eStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly HttpClient client = null;
        private string ProductApiUrl = "";
        public ProductsController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ProductApiUrl = "https://localhost:7211/api/Products";
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl + "/GetProducts");
            List<Product>? products = new List<Product>();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                products = response.Content.ReadFromJsonAsync<List<Product>>().Result;
            }

            HttpResponseMessage response2 = await client.GetAsync(ProductApiUrl + "/GetCategories");
            List<Category>? categories = new List<Category>();
            if (response2.StatusCode == System.Net.HttpStatusCode.OK)
            {
                categories = response2.Content.ReadFromJsonAsync<List<Category>>().Result;
            }
            ViewData["CategoryId"] = new SelectList(categories, "CategoryId", "CategoryName");

            return View(products);
        }

        //GET: ProductsController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl + "/GetProductById/" + id);

            Product product = new Product();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                product = response.Content.ReadFromJsonAsync<Product>().Result;
            }

            HttpResponseMessage response2 = await client.GetAsync(ProductApiUrl + "/GetCategories");
            List<Category>? categories = new List<Category>();
            if (response2.StatusCode == System.Net.HttpStatusCode.OK)
            {
                categories = response2.Content.ReadFromJsonAsync<List<Category>>().Result;
            }
            ViewData["CategoryId"] = new SelectList(categories, "CategoryId", "CategoryName");
            return View(product);
        }

        //GET: ProductsController/Create
        public async Task<IActionResult> Create()
        {
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl + "/GetCategories");
            List<Category>? categories = new List<Category>();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                categories = response.Content.ReadFromJsonAsync<List<Category>>().Result;
            }
            ViewData["CategoryId"] = new SelectList(categories, "CategoryId", "CategoryName");

            return View();
        }

        //POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product p)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(ProductApiUrl + "/PostProduct", p);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return Redirect("Create");
        }

        //GET: ProductsController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl + "/GetProductById/" + id);
            Product product = new Product();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                product = response.Content.ReadFromJsonAsync<Product>().Result;
            }

            HttpResponseMessage response2 = await client.GetAsync(ProductApiUrl + "/GetCategories");
            List<Category>? categories = new List<Category>();
            if (response2.StatusCode == System.Net.HttpStatusCode.OK)
            {
                categories = response2.Content.ReadFromJsonAsync<List<Category>>().Result;
            }
            ViewData["CategoryId"] = new SelectList(categories, "CategoryId", "CategoryName");

            return View(product);
        }

        //POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product p)
        {
            if (ModelState.IsValid)
            {
                await client.PutAsJsonAsync(ProductApiUrl + "/UpdateProduct/" + id, p);
                return RedirectToAction("Index");
            }
            return View(p);
        }

        //GET: ProductsController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            await client.DeleteAsync(ProductApiUrl + "/DeleteProduct/" + id);
            return RedirectToAction("Index");
        }
    }
}
