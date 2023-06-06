using EvaraWebApp.DataContext;
using EvaraWebApp.Extensions;
using EvaraWebApp.Models;
using EvaraWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EvaraWebApp.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class SliderController : Controller
{

    private readonly EvaraDbContext _evaraDbContext;
    private readonly IWebHostEnvironment _environment;

    public SliderController(EvaraDbContext evaraDbContext, IWebHostEnvironment environment)
    {
        _evaraDbContext = evaraDbContext;
        _environment = environment;
    }
    public async Task<IActionResult> Index()
    {
        List<Slider> sliders = await _evaraDbContext.Sliders.ToListAsync();
        return View(sliders);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateSliderVM slider)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        if (!slider.Image.CheckType("image/") && !slider.Image.CheckSize(2048))
        {
            ModelState.AddModelError("Image", "File type must be image or 2mb");
            return View();
        }

        string newFileName = await slider.Image.UploadAsync(_environment.WebRootPath, "assets", "imgs", "slider");

        Slider newSlider = new Slider()
        {
            Description = slider.Description,
            Title = slider.Title,
            ImageName = newFileName
        };
        _evaraDbContext.Sliders.Add(newSlider);
        await _evaraDbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        Slider? slider = await _evaraDbContext.Sliders.FindAsync(id);
        if (slider == null)
        {
            return NotFound();
        }
        if (slider.ImageName != null)
        {
            string filePath = Path.Combine(_environment.WebRootPath, "assets", "imgs", "slider", slider.ImageName);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

        }
        _evaraDbContext.Sliders.Remove(slider);
        await _evaraDbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        Slider? slider = await _evaraDbContext.Sliders.FindAsync(id);
        if (slider == null) return NotFound();
        EditSliderVM sliderVM = new EditSliderVM()
        {
            Description = slider.Description,
            ImageName = slider.ImageName,
            Title = slider.Title,
        };
        return View(sliderVM);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, EditSliderVM sliderVm)
    {
        Slider? slider = await _evaraDbContext.Sliders
                .AsNoTracking()
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

        if (slider == null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(sliderVm);
        }
        if (sliderVm.Image != null)
        {
            //file upload
            //string newFileName = Guid.NewGuid().ToString() + sliderVm.Image.FileName;
            string imagePath = Path.Combine(_environment.WebRootPath, "assets", "imgs", "slider", slider.ImageName);
            using (FileStream fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await sliderVm.Image.CopyToAsync(fileStream);
            }
            sliderVm.ImageName = slider.ImageName;
        }
        else
        {
            sliderVm.ImageName = slider.ImageName;
        }

        Slider newDbSlider = new Slider()
        {
            Id = id,
            Title = sliderVm.Title,
            Description = sliderVm.Description,
            ImageName = sliderVm.ImageName,
        };

        _evaraDbContext.Sliders.Update(newDbSlider);

        await _evaraDbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
