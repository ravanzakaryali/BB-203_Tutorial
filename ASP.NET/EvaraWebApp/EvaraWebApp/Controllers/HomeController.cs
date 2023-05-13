using EvaraWebApp.DataContext;
using EvaraWebApp.Models;
using EvaraWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Imaging;
using System.Net;
using System.Security.Cryptography.Xml;

namespace EvaraWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly EvaraDbContext _context;
        public HomeController(EvaraDbContext evaraDbContext)
        {
            _context = evaraDbContext;
        }

        public async Task<IActionResult> Index()
        {

            HttpContext.Response.Cookies.Append("test", "BB203", new CookieOptions()
            {
                MaxAge = TimeSpan.FromMinutes(10)
            });
            //HttpContext.Session.Set("test", new byte[] { 25,20 });
            List<Slider> sliders = await _context.Sliders.ToListAsync();
            HomeVM homeVM = new HomeVM()
            {
                //Products = products,
                Sliders = sliders
            };
            return View(homeVM);
        }
        public IActionResult GetSession()
        {
            return Json(HttpContext.Session.Get("test"));
        }
        public IActionResult GetCookie()
        {
            return Json(HttpContext.Request.Cookies["test"]);
        }

        //public IActionResult About()
        //{
        //    //10
        //    //date 5:49
        //    List<Slider> sliders = _dbContext.Sliders.ToList();
        //    return View(sliders);
        //}
    }
}