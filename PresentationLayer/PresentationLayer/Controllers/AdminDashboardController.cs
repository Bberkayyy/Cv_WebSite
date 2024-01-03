using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class AdminDashboardController : Controller
{
    public IActionResult Index()
    {
        ViewBag.v1 = "Dashboard";
        ViewBag.v2 = "İStatistikler";
        return View();
    }
}
