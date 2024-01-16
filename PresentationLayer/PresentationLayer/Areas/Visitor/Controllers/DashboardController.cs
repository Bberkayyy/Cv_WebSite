using Dtos.VisitorMessageDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Xml.Linq;

namespace WebUI.Areas.Visitor.Controllers;

[Area("Visitor")]
[Route("Visitor/[controller]")]
[Authorize]
public class DashboardController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly UserManager<VisitorUser> _userManager;

    public DashboardController(UserManager<VisitorUser> userManager, IHttpClientFactory httpClientFactory)
    {
        _userManager = userManager;
        _httpClientFactory = httpClientFactory;
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


        string currentMail = visitor.Email;
        var client = _httpClientFactory.CreateClient();


        var responseMessageSender = await client.GetAsync($"https://localhost:7181/api/VisitorMessages/getSenderMessageCount?mail=" + currentMail);
        if (responseMessageSender.IsSuccessStatusCode)
        {
            var jsonDataSender = await responseMessageSender.Content.ReadAsStringAsync();
            var valueSender = JsonConvert.DeserializeObject<int>(jsonDataSender);
            ViewBag.MessageSender = valueSender;
        }
        var responseMessageReceiver = await client.GetAsync($"https://localhost:7181/api/VisitorMessages/getReceiverMessageCount?mail=" + currentMail);
        if (responseMessageReceiver.IsSuccessStatusCode)
        {
            var jsonDataReceiver = await responseMessageReceiver.Content.ReadAsStringAsync();
            var valueReceiver = JsonConvert.DeserializeObject<int>(jsonDataReceiver);
            ViewBag.MessageReceiver = valueReceiver;
        }
        return View();
    }
}
