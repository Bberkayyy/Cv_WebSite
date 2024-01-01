using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class AdminFeatureController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
