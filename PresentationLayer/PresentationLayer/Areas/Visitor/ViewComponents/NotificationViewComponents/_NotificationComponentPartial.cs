using Dtos.AnnouncementDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Areas.Visitor.ViewComponents.NotificationViewComponents;

public class _NotificationComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _NotificationComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7181/api/Announcements/getall");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAnnouncementDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
