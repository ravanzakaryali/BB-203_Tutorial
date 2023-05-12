using EvaraWebApp.DataContext;
using EvaraWebApp.Models;
using EvaraWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            //date - 5:49
            //--- 10 dəq
            //date - 5:49

            //List<Category> categories = await _dbContext.Categories.Include(c => c.Products).ToListAsync();
            List<Slider> sliders = await _context.Sliders.ToListAsync();
            //List<Product> products = await _context.Products.Include(c=>c.Category).Include(p=>p.Images).ToListAsync();
            HomeVM homeVM = new HomeVM()
            {
                //Products = products,
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