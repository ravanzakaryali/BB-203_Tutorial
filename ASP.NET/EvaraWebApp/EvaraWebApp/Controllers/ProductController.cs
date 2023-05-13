using EvaraWebApp.DataContext;
using EvaraWebApp.Models;
using EvaraWebApp.ViewModels.ProductVM;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EvaraWebApp.Controllers;

public class ProductController : Controller
{
    private readonly EvaraDbContext _evaraDbContext;

    public ProductController(EvaraDbContext evaraDbContext)
    {
        _evaraDbContext = evaraDbContext;
    }

    public async Task<IActionResult> AddCart(int id)
    {
        //Cookie append
        Product? product = await _evaraDbContext.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        //1. Cookie baxıram
        string? value = HttpContext.Request.Cookies["basket"];
        List<CartVM> cartsCookie = new List<CartVM>();
        if (value == null)
        {
            HttpContext.Response.Cookies.Append("basket", JsonSerializer.Serialize(cartsCookie));
        }
        else
        {
            cartsCookie = JsonSerializer.Deserialize<List<CartVM>>(value);
        }

        CartVM? cart = cartsCookie.Find(c => c.Id == id);
        if (cart == null)
        {
            cartsCookie.Add(new CartVM()
            {
                Id = id,
                Count = 1
            });
        }
        else
        {
            cart.Count += 1;
        }
        HttpContext.Response.Cookies.Append("basket", JsonSerializer.Serialize(cartsCookie), new CookieOptions()
        {
            MaxAge = TimeSpan.FromDays(1)
        });
        return RedirectToAction("Index", "Home");
    }
    public async IActionResult GetCarts()
    {

        string value = HttpContext.Request.Cookies["basket"];
        List<CartVM> cartVM = JsonSerializer.Deserialize<List<CartVM>>(value);
        List<Product> products = new List<Product>();
        foreach (var item in cartVM)
        {
            Product product = await _evaraDbContext.Products.FindAsync(item.Id);
            products.Add(product);
        }
        return View(products);
    }
}
