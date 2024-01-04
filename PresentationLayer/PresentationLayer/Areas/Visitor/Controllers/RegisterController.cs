using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Visitor.Controllers;

[Area("Visitor")]
public class RegisterController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Index(int a)
    {
        return View();
    }
}
