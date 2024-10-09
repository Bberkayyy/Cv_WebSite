using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[AllowAnonymous]
public class ErrorPagesController : Controller
{
    public IActionResult Error404()
    {
        return View();
    }
    public IActionResult Error403()
    {
        return View();
    }
}
