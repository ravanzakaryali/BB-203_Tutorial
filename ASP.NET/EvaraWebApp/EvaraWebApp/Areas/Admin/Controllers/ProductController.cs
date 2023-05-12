using EvaraWebApp.DataContext;
using EvaraWebApp.Models;
using EvaraWebApp.ViewModels.ProductVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EvaraWebApp.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController : Controller
{
    readonly EvaraDbContext _evaraDbContext;
    readonly IWebHostEnvironment _webHostEnvironment;

    public ProductController(EvaraDbContext evaraDbContext, IWebHostEnvironment webHostEnvironment)
    {
        _evaraDbContext = evaraDbContext;
        _webHostEnvironment = webHostEnvironment;
    }
    public async Task<IActionResult> Index()
    {
        List<Product> products = await _evaraDbContext.Products.Include(p=>p.Images).ToListAsync();

        List<GetProductVM> productsVM = new List<GetProductVM>();
        foreach (Product product in products)
        {
            productsVM.Add(new GetProductVM()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImageName = product.Images.FirstOrDefault().ImageName
            });
        }
        return View(productsVM);
    }
    public async Task<IActionResult> Create()
    {
        List<Category> categories = await _evaraDbContext.Categories.ToListAsync();
        //CreateProductVM productVM = new CreateProductVM()
        //{
        //    Categories = categories
        //};

        //return View(productVM);
        ViewData["Categories"] = categories;
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateProductVM newProduct)
    {
        List<Category> categories = await _evaraDbContext.Categories.ToListAsync();
        if (!ModelState.IsValid)
        {
            ViewData["Categories"] = categories;
            return View();
        }
        Product product = new Product()
        {
            CategoryId = newProduct.CategoryId,
            Name = newProduct.Name,
            Price = newProduct.Price,
            Description = newProduct.Description,
        };
        List<Image> images = new List<Image>();
        foreach (IFormFile item in newProduct.Images)
        {
            string guid = Guid.NewGuid().ToString();
            string newFileName = guid + item.FileName;
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "imgs", "shop", newFileName);
            using(FileStream fileStream = new FileStream(path, FileMode.CreateNew))
            {
                await item.CopyToAsync(fileStream);
            }
            images.Add(new Image()
            {
                ImageName = newFileName,
            });
        }
        product.Images = images;
        await _evaraDbContext.Products.AddAsync(product);
        await _evaraDbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
