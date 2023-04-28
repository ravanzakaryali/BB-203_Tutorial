using Microsoft.AspNetCore.Mvc;

namespace InsureWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
