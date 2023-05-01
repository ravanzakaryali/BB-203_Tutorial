using EvaraWebApp.DataContext;
using EvaraWebApp.Models;
using EvaraWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EvaraWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly EvaraDbContext _dbContext;
        public HomeController(EvaraDbContext evaraDbContext)
        {
            _dbContext = evaraDbContext;
        }
        public async Task<IActionResult> Index()
        {
            //date - 5:49
            //--- 10 dəq
            //date - 5:49
            List<Category> categories = await _dbContext.Categories.Include(c=>c.Products).ToListAsync();
            List<Slider> sliders = await _dbContext.Sliders.ToListAsync();
            List<Product> products = await _dbContext.Products.Include(c => c.Category).ToListAsync();
            HomeVM homeVM = new HomeVM()
            {
                Products = products,
                Sliders = sliders
            };
            return View(homeVM);
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