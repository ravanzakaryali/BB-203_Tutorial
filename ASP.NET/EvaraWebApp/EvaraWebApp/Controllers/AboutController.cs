using EvaraWebApp.DataContext;
using Microsoft.AspNetCore.Mvc;

namespace EvaraWebApp.Controllers
{
    public class AboutController : Controller
    {
        private readonly EvaraDbContext _dbContext;
        public AboutController(EvaraDbContext evaraDbContext)
        {
            _dbContext = evaraDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
