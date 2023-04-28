using Microsoft.AspNetCore.Mvc;

namespace InsureWebApp.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
