using Microsoft.AspNetCore.Mvc;

namespace FirstWebApplication.Controllers;

public class HomeController : Controller
{
    //public ViewResult Index()
    //{
    //    ViewResult viewResult = new ViewResult();
    //    viewResult.ViewName = "Index";
    //    return viewResult;
    //}
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Users()
    {
        return View();
    }
}
