using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Visitor.Controllers;

[Area("Visitor")]
[Route("Visitor/Default")]
public class DefaultController : Controller
{
    [Route("Index")]
    public IActionResult Index()
    {
        return View();
    }
}
