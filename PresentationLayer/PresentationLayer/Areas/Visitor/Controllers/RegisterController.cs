using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Visitor.Models;

namespace WebUI.Areas.Visitor.Controllers;

[Area("Visitor")]
[Route("Visitor/Register")]
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
            var result = await _userManager.CreateAsync(visitorUser, registerViewModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
        return View(registerViewModel);
    }
}
