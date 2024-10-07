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
    public class CategoriesController : Controller
    {
        private readonly HttpClient client = null;
        private string CategoryApiUrl = "";
        public CategoriesController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            CategoryApiUrl = "https://localhost:7211/api/Categories";
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync(CategoryApiUrl + "/GetCategories");
            List<Category>? categories = new List<Category>();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                categories = response.Content.ReadFromJsonAsync<List<Category>>().Result;
            }

            return View(categories);
        }

        //GET: CategoriesController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage response = await client.GetAsync(CategoryApiUrl + "/GetCategoryById/" + id);

            Category category = new Category();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                category = response.Content.ReadFromJsonAsync<Category>().Result;
            }

            return View(category);
        }

        //GET: CategoriesController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        //POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category c)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(CategoryApiUrl + "/PostCategory", c);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return Redirect("Create");
        }

        //GET: CategoriesController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            HttpResponseMessage response = await client.GetAsync(CategoryApiUrl + "/GetCategoryById/" + id);
            Category category = new Category();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                category = response.Content.ReadFromJsonAsync<Category>().Result;
            }

            return View(category);
        }

        //POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category c)
        {
            if (ModelState.IsValid)
            {
                await client.PutAsJsonAsync(CategoryApiUrl + "/UpdateCategory/" + id, c);
                return RedirectToAction("Index");
            }
            return View(c);
        }

    }
}
