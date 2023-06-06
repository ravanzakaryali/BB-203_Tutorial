using EvaraWebApp.DataContext;
using EvaraWebApp.Extensions;
using EvaraWebApp.Models;
using EvaraWebApp.ViewModels.ProductVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EvaraWebApp.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
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
        List<Product> products = await _evaraDbContext.Products
                        .Include(p => p.Images)
                        .Include(p => p.Colors)
                        .ToListAsync();

        List<GetProductVM> productsVM = new List<GetProductVM>();
        foreach (Product product in products)
        {
            List<string> colors = product.Colors.Select(c => c.Code).ToList();
            productsVM.Add(new GetProductVM()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImageName = product.Images.FirstOrDefault().ImageName,
                Colors = colors
            });
        }
        return View(productsVM);
    }
    public async Task<IActionResult> Create()
    {
        List<Category> categories = await _evaraDbContext.Categories.ToListAsync();
        List<Color> colors = await _evaraDbContext.Colors.ToListAsync();
        CreateProductVM productVM = new CreateProductVM()
        {
            Categories = categories,
            Colors = colors
        };

        return View(productVM);
        //ViewData["Categories"] = categories;
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateProductVM newProduct)
    {

        List<Color> colors = await _evaraDbContext.Colors.ToListAsync();
        List<Category> categoriesDb = await _evaraDbContext.Categories.ToListAsync();
        if (!ModelState.IsValid)
        {
            newProduct.Colors = colors;
            newProduct.Categories = categoriesDb;
            return View(newProduct);
        }
        Category? category = await _evaraDbContext.Categories.FindAsync(newProduct.CategoryId);
        if (category == null)
        {
            newProduct.Colors = colors;
            newProduct.Categories = categoriesDb;
            ModelState.AddModelError("CategoryId", "Category not found");
            return View(newProduct);
        }

        Product product = new Product()
        {
            CategoryId = newProduct.CategoryId,
            Name = newProduct.Name,
            Price = newProduct.Price,
            Description = newProduct.Description,
        };

        foreach (int id in newProduct.ColorsId)
        {
            Color? color = await _evaraDbContext.Colors.FindAsync(id);
            if (color == null)
            {
                ModelState.AddModelError("ColorsId", "Color not found");
                return View(newProduct);
            }
            product.Colors.Add(color);
        }


        List<Image> images = new List<Image>();
        foreach (IFormFile item in newProduct.Images)
        {
            //string guid = Guid.NewGuid().ToString();
            //string newFileName = guid + item.FileName;

            //string path = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "imgs", "shop", newFileName);
            //using (FileStream fileStream = new FileStream(path, FileMode.CreateNew))
            //{
            //    await item.CopyToAsync(fileStream);
            //}
         
            if (item.CheckType("image/") && item.CheckSize(1024))
            {
                newProduct.Categories = categoriesDb;
                newProduct.Colors = colors;

                ModelState.AddModelError("Images", "Error");
                return View(newProduct);
            }
            string fileName = await item.UploadAsync(_webHostEnvironment.WebRootPath, "assets", "imgs", "shop");
            images.Add(new Image()
            {
                ImageName = fileName,
            });
        }
        product.Images = images;
        await _evaraDbContext.Products.AddAsync(product);
        await _evaraDbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
