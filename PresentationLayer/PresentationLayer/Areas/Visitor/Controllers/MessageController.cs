using Dtos.AnnouncementDtos;
using Dtos.VisitorMessageDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebUI.Areas.Visitor.Controllers;

[Area("Visitor")]
[Route("Visitor/[controller]")]
[Authorize(Roles = "Visitor")]
public class MessageController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly UserManager<VisitorUser> _userManager;

    public MessageController(IHttpClientFactory httpClientFactory, UserManager<VisitorUser> userManager)
    {
        _httpClientFactory = httpClientFactory;
        _userManager = userManager;
    }

    [Route("ReceiverMessages")]
    public async Task<IActionResult> ReceiverMessages(string mail)
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        mail = user.Email;
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7181/api/VisitorMessages/getReceiverMessages?receiverMail=" + mail);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultVisitorMessageDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [Route("SenderMessages")]
    public async Task<IActionResult> SenderMessages(string mail)
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        mail = user.Email;
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7181/api/VisitorMessages/getSenderMessages?senderMail=" + mail);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultVisitorMessageDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("Details/{id}")]
    public async Task<IActionResult> MessageDetails(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7181/api/VisitorMessages/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<ResultVisitorMessageDto>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpGet]
    [Route("Detail/{id}")]
    public async Task<IActionResult> ReceiverMessageDetails(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7181/api/VisitorMessages/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<ResultVisitorMessageDto>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpGet]
    [Route("NewMessage")]
    public IActionResult NewMessage()
    {
        return View();
    }
    [HttpPost]
    [Route("NewMessage")]
    public async Task<IActionResult> NewMessage(CreateNewMessageDto newMessageDto)
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        newMessageDto.SenderMail = user.Email;
        newMessageDto.SenderName = user.Name + " " + user.Surname;
        newMessageDto.SendDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        var receiverName = _userManager.Users.Where(x => x.Email == newMessageDto.ReceiverMail).Select(n => n.Name + " " + n.Surname).FirstOrDefault();
        newMessageDto.ReceiverName = receiverName;

        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(newMessageDto);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7181/api/VisitorMessages/add", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("SenderMessages", "Message", new { area = "Visitor" });
        return View();
    }
}
