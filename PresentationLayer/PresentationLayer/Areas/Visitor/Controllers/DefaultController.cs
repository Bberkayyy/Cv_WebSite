using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Visitor.Controllers;

[Area("Visitor")]
public class DefaultController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
