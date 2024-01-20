using Dtos.MessageDtos;
using Dtos.VisitorMessageDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebUI.Controllers;
[Authorize]
public class AdminVisitorMessageController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly UserManager<VisitorUser> _userManager;

    public AdminVisitorMessageController(IHttpClientFactory httpClientFactory, UserManager<VisitorUser> userManager)
    {
        _httpClientFactory = httpClientFactory;
        _userManager = userManager;
    }

    public async Task<IActionResult> Inbox()
    {
        ViewBag.v1 = "Mesajlar";
        ViewBag.v2 = "Kullanıcılardan Gelen Mesajlar";
        TempData["Url"] = "Inbox";
        string mail = "admin@gmail.com";
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7181/api/VisitorMessages/getReceiverMessages?receiverMail=" + mail);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAdminVisitorMessageDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    public async Task<IActionResult> Sendbox()
    {
        ViewBag.v1 = "Mesajlar";
        ViewBag.v2 = "Gönderilen Mesajlar";
        TempData["Url"] = "Sendbox";
        string mail = "admin@gmail.com";
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7181/api/VisitorMessages/getSenderMessages?senderMail=" + mail);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAdminVisitorMessageDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    public async Task<IActionResult> Details(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7181/api/VisitorMessages/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<ResultAdminVisitorMessageDto>(jsonData);
            return View(value);
        }
        return View();
    }
    public async Task<IActionResult> Delete(int id)
    {
        var viewUrl = TempData["Url"].ToString();
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"https://localhost:7181/api/VisitorMessages/{id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction(viewUrl);
        return View();
    }
    [HttpGet]
    public IActionResult SendMessage()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> SendMessage(CreateAdminVisitorMessageDto messageDto)
    {
        messageDto.SenderName = "Admin";
        messageDto.SenderMail = "admin@gmail.com";
        var receiverName = _userManager.Users.Where(x => x.Email == messageDto.ReceiverMail).Select(n => n.Name + " " + n.Surname).FirstOrDefault();
        messageDto.ReceiverName = receiverName;
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(messageDto);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7181/api/VisitorMessages/add", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Sendbox");
        return View();
    }
}
