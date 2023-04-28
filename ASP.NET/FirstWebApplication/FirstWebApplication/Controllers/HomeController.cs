using FirstWebApplication.Models;
using FirstWebApplication.ViewModels;
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
        //ViewBag, ViewData, TempData
        //ViewBag.Sahbaz = "Chingiz";
        //ViewData["Name"] = "View data Chingiz";
        //TempData["Name"] = "Temp data Chingiz";
        //return RedirectToAction("Users", "Salam");
        //string name = "Elvin";
        List<Student> students = new List<Student>()
        {
            new Student()
            {
                Age = 20,
                Id = 1,
                Name = "Chingiz"
            },
            new Student()
            {
                Id = 2,
                Age = 20,
                Name = "Mammad"
            },
            new Student()
            {
                Id = 3,
                Age = 20,
                Name = "Namiq"
            }
        };

        List<Book> books = new List<Book>()
        {
            new Book()
            {
                Id = 1,
                Title = "Title",
            },
            new Book() {
                Id = 2,
                Title = "Title2",
            }
        };
        SchoolVM schoolVM = new SchoolVM()
        {
            Books = books,
            Students = students
        };
        return View(schoolVM);
    }
    public IActionResult Users()
    {
        Book book = new Book()
        {

            Id = 1,
            Title = "Book title"
        };
        BookVM bookVM = new BookVM()
        {
            Title = book.Title,
        };
        return View(bookVM);
    }
}
