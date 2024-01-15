using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Visitor.Models;

namespace WebUI.Areas.Visitor.Controllers;

[Area("Visitor")]
[Route("Visitor/[controller]")]
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
                return RedirectToAction("Index", "Default", new { area = "Visitor" });
            }
            else
            {
                ModelState.AddModelError("", "Hatalı kullanıcı adı veya şifre!");
            }
        }
        return View();
    }
}
