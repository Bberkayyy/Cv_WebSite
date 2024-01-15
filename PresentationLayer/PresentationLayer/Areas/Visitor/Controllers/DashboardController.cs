using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace WebUI.Areas.Visitor.Controllers;

[Area("Visitor")]
[Route("Visitor/[controller]")]
[Authorize]
public class DashboardController : Controller
{
    private readonly UserManager<VisitorUser> _userManager;

    public DashboardController(UserManager<VisitorUser> userManager)
    {
        _userManager = userManager;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var visitor = await _userManager.FindByNameAsync(User.Identity.Name);
        ViewBag.VisitorName = visitor.Name + " " + visitor.Surname;

        string apiKey = "20403d03ccd28cbc06a976b750e95c83";
        string conntection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + apiKey;
        XDocument document = XDocument.Load(conntection);
        ViewBag.weather = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

        return View();
    }
}
