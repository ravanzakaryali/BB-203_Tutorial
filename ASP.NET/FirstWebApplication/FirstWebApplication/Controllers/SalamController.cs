using Microsoft.AspNetCore.Mvc;

namespace FirstWebApplication.Controllers;

public class SalamController : Controller
{
    public string Chingiz()
    {
        return "Salam Controller";
    }
    public IActionResult Users()
    {
        return View();
    }
}
