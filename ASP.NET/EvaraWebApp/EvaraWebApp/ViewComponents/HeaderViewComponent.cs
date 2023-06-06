using EvaraWebApp.DataContext;
using EvaraWebApp.Models;
using EvaraWebApp.ViewModels.ProductVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace EvaraWebApp.ViewComponents;

public class HeaderViewComponent : ViewComponent
{

    private readonly EvaraDbContext _evaraDbContext;

    public HeaderViewComponent(EvaraDbContext evaraDbContext)
    {
        _evaraDbContext = evaraDbContext;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        string value = HttpContext.Request.Cookies["basket"];
        if (value != null)
        {
            List<CartVM> cartVM = JsonSerializer.Deserialize<List<CartVM>>(value);
            ViewData["count"] = cartVM.Count;
            ViewData["products"] = cartVM;
        }
        ViewData["products"] = new List<CartVM>();
        Dictionary<string, Setting> settings = await _evaraDbContext.Settings.ToDictionaryAsync(c => c.Key);
        return View(settings);
    }
}
