using Microsoft.AspNetCore.Mvc;

namespace eStoreClient.Controllers
{
    public class Login : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
