using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;
[Authorize]
public class AdminDashboardController : Controller
{
    public IActionResult Index()
    {
        ViewBag.v1 = "Dashboard";
        ViewBag.v2 = "İstatistikler";
        return View();
    }
}
