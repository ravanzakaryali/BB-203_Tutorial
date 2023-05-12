using EvaraWebApp.DataContext;
using EvaraWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EvaraWebApp.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController : Controller
{
    private readonly EvaraDbContext _evaraDbContext;

    public CategoryController(EvaraDbContext evaraDbContext)
    {
        _evaraDbContext = evaraDbContext;
    }

    public async Task<IActionResult> Index()
    {
        List<Category> categories = await _evaraDbContext.Categories.ToListAsync();

        return View(categories);
    }
    public async Task<IActionResult> Detail(int id)
    {
        Category? category = await _evaraDbContext.Categories.FindAsync(id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Category category)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        if (_evaraDbContext.Categories.Any(c => c.Name.Trim().ToLower() == category.Name.Trim().ToLower()))
        {
            ModelState.AddModelError("Name", "Category already exist");
            return View();
        }
        await _evaraDbContext.Categories.AddAsync(category);
        await _evaraDbContext.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        Category? category = await _evaraDbContext.Categories.FindAsync(id);
        if (category == null)
        {
            return NotFound();
        }
        _evaraDbContext.Categories.Remove(category);
        await _evaraDbContext.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        Category? category = await _evaraDbContext.Categories.FindAsync(id);
        if (category == null) return NotFound();
        return View(category);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Category newCategory)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        Category? category = await _evaraDbContext.Categories.FindAsync(id);
        if (category == null) return NotFound();
        if (_evaraDbContext.Categories.Any(c => c.Name.ToLower().Trim() == newCategory.Name.ToLower().Trim()))
        {
            ModelState.AddModelError("Name", "Category already exist");
            return View();
        }

        category.Name = newCategory.Name;
        await _evaraDbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
