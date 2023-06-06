using EvaraWebApp.DataContext;
using EvaraWebApp.Models;
using EvaraWebApp.Services.Abstracts;
using EvaraWebApp.Services.Concrets;
using EvaraWebApp.ViewModels.AccountVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace EvaraWebApp.Controllers;

public class AccountController : Controller
{

    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IEmailService _emailService;

    public AccountController(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        RoleManager<IdentityRole> roleManager,
        IEmailService emailService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _emailService = emailService;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Register(RegisterVM register)
    {
        if (!ModelState.IsValid)
        {
            return View(register);
        }
        AppUser newUser = new AppUser()
        {
            Name = register.Name,
            Surname = register.Surname,
            Email = register.Email,
            UserName = register.UserName,
        };
        IdentityResult identityResult = await _userManager.CreateAsync(newUser, register.Password);
        if (!identityResult.Succeeded)
        {
            foreach (IdentityError? error in identityResult.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(register);
        }

        #region Add Role
        //IdentityResult roleResult = await _userManager.AddToRoleAsync(newUser, "Admin");
        //if (!roleResult.Succeeded)
        //{
        //    foreach (IdentityError? error in identityResult.Errors)
        //    {
        //        ModelState.AddModelError("", error.Description);
        //    }
        //    return View(register);
        //}
        #endregion

        string token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);


        string link = Url.Action("ConfirmUser", "Account", new { email = newUser.Email, token = token }, HttpContext.Request.Scheme);

        _emailService.SendMessage(token, "Confirm", newUser.Email);

        return RedirectToAction(nameof(Login));
    }

    public async Task<IActionResult> ConfirmUser(string email, string token)
    {

        AppUser user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            return NotFound();
        }
        IdentityResult identityResult = await _userManager.ConfirmEmailAsync(user, token);
        if (!identityResult.Succeeded)
        {
            ModelState.AddModelError("", "Token confirm incorrect");
            return View();
        }
        //await _signInManager.SignInAsync(user, true);
        return RedirectToAction("Login");
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginVM login)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        AppUser user = await _userManager.FindByNameAsync(login.UserName);
        if (user == null)
        {
            ModelState.AddModelError("", "Invalid username or password");
            return View(login);
        }
        //_signInManager.SignInAsync(user);
        Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, login.Password, true, false);
        if (!signInResult.Succeeded)
        {
            ModelState.AddModelError("", "Invalid username or password");
            return View(login);
        }
        return RedirectToAction("Index", "Home");
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    //public async Task<IActionResult> CreateRole()
    //{
    //    IdentityRole role = new IdentityRole()
    //    {
    //        Name = "Admin"
    //    };
    //    IdentityResult result = await _roleManager.CreateAsync(role);
    //    if (!result.Succeeded)
    //    {
    //        return NotFound();
    //    }
    //    return Json("Ok");
    //}
}
