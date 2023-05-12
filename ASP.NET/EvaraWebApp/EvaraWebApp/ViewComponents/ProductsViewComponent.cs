using EvaraWebApp.DataContext;
using EvaraWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EvaraWebApp.ViewComponents;

public class ProductsViewComponent : ViewComponent
{
    private readonly EvaraDbContext _evaraDbContext;

    public ProductsViewComponent(EvaraDbContext evaraDbContext)
    {
        _evaraDbContext = evaraDbContext;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        List<Product> products = await _evaraDbContext.Products.Include(p => p.Images).ToListAsync();
        return View(products);
    }
}
