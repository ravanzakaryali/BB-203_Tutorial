using EvaraWebApp.DataContext;
using EvaraWebApp.Models;
using EvaraWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EvaraWebApp.Controllers
{
    public class AboutController : Controller
    {
        private readonly EvaraDbContext _dbContext;
        public AboutController(EvaraDbContext evaraDbContext)
        {
            _dbContext = evaraDbContext;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
