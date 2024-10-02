using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ODataBookStoreWebClient.Models;
using System.Net.Http.Headers;

namespace ODataBookStoreWebClient.Controllers
{
    public class PressController : Controller
    {
        private readonly HttpClient client = null;
        private string ProductApiUrl = "";

        public PressController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ProductApiUrl = "https://localhost:7163/odata/Presses";
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl);
            string strData = await response.Content.ReadAsStringAsync();

            dynamic temp = JObject.Parse(strData);
            var lst = temp.value;
            List<Press> items = ((JArray)temp.value).Select(x => new Press
            {
                Id = (int)x["Id"],
                Name = (string)x["Name"],
            }).ToList();
            return View(items);
        }
    }
}
