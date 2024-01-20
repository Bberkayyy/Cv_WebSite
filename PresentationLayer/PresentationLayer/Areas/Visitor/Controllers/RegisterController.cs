using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Visitor.Models;

namespace WebUI.Areas.Visitor.Controllers;

[Area("Visitor")]
[Route("Visitor/[controller]")]
[AllowAnonymous]
public class RegisterController : Controller
{
    private readonly UserManager<VisitorUser> _userManager;

    public RegisterController(UserManager<VisitorUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    [Route("Index")]
    public IActionResult Index()
    {
        return View(new VisitorUserRegisterViewModel());
    }
    [HttpPost]
    [Route("Index")]
    public async Task<IActionResult> Index(VisitorUserRegisterViewModel registerViewModel)
    {

        VisitorUser visitorUser = new VisitorUser()
        {
            Name = registerViewModel.Name,
            Surname = registerViewModel.Surname,
            Email = registerViewModel.Mail,
            UserName = registerViewModel.UserName,
        };
        if (registerViewModel.Password == registerViewModel.ConfirmPassword)
        {
            var result = await _userManager.CreateAsync(visitorUser, registerViewModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login", new { area = "Visitor" });
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
        }
        return View(registerViewModel);
    }
}
