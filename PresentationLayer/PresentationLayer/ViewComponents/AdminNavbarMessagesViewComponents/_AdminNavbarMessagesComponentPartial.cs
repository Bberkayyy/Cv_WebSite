using Dtos.MessageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace WebUI.ViewComponents.AdminNavbarMessagesViewComponents;

public class _AdminNavbarMessagesComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _AdminNavbarMessagesComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        string mail = "admin@gmail.com";
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7181/api/VisitorMessages/getLast3ReceiverMessage?mail=" + mail);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLast3MessageReceiverAdminDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
