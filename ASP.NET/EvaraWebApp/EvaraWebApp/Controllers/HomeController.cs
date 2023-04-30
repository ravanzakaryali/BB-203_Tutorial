using EvaraWebApp.DataContext;
using EvaraWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EvaraWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly EvaraDbContext _dbContext;
        public HomeController(EvaraDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Slider> slider = _dbContext.Sliders.ToList();
            return View();
        }
    }
}