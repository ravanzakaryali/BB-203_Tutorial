using EvaraWebApp.DataContext;
using EvaraWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        Dictionary<string, Setting> settings = await _evaraDbContext.Settings.ToDictionaryAsync(c=>c.Key);
        return View(settings);
    }
}
