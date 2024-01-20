using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class ErrorPagesController : Controller
{
    public IActionResult Error404()
    {
        return View();
    }
}
