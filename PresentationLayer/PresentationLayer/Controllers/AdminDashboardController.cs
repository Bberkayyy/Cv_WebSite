using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class AdminDashboardController : Controller
{
    public IActionResult Index()
    {
        ViewBag.v1 = "Dashboard";
        ViewBag.v2 = "İstatistikler";
        return View();
    }
}
