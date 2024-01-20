using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class AdminLoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
