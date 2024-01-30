using Dtos.ExperianceDtos;
using Dtos.MessageDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Controllers;

[Authorize(Roles = "Admin")]
public class AdminMessageController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminMessageController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.v1 = "Mesajlar";
        ViewBag.v2 = "Siteden Gelen Mesajlar";
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7181/api/Messages/getall");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultMessageDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    public async Task<IActionResult> RemoveMessage(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"https://localhost:7181/api/Messages/{id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index");
        return View();
    }
    public async Task<IActionResult> MessageDetail(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7181/api/Messages/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<MessageDetailDto>(jsonData);
            return View(value);
        }
        return View();
    }
    public async Task<IActionResult> MessageStatus(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7181/api/Messages/" + id);
        var data = await responseMessage.Content.ReadAsStringAsync();
        var updateData = JsonConvert.DeserializeObject<ResultMessageDto>(data);
        if (updateData.Status is false)
            await client.GetAsync("https://localhost:7181/api/Messages/MessageStatusToTrue?id=" + id);
        else
            await client.GetAsync("https://localhost:7181/api/Messages/MessageStatusToFalse?id=" + id);
        return RedirectToAction("Index");
    }
}
