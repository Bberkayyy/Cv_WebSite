using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Visitor.Models;

namespace WebUI.Areas.Visitor.Controllers;

[Area("Visitor")]
[Route("Visitor/[controller]")]
[AllowAnonymous]
public class LoginController : Controller
{
    private readonly SignInManager<VisitorUser> _signInManager;

    public LoginController(SignInManager<VisitorUser> signInManager)
    {
        _signInManager = signInManager;
    }
    [HttpGet]
    [Route("Index")]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    [Route("Index")]
    public async Task<IActionResult> Index(VisitorUserLoginViewModel loginViewModel)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, true, true);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ModelState.AddModelError("", "Hatalı kullanıcı adı veya şifre!");
            }
        }
        return View();
    }
    [Route("Logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Login", new { area = "Visitor" });
    }
}
