using Dtos.UserMessageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.ViewComponents.AdminDashboardUserMessageViewComponents;

public class _AdminDashboardUserMessageComponentPartial : ViewComponent
{
    //private readonly IHttpClientFactory _httpClientFactory;

    //public _AdminDashboardUserMessageComponentPartial(IHttpClientFactory httpClientFactory)
    //{
    //    _httpClientFactory = httpClientFactory;
    //}

    public async Task<IViewComponentResult> InvokeAsync()
    {
        //var client = _httpClientFactory.CreateClient();
        //var responseMessage = await client.GetAsync("https://localhost:7181/api/UserMessages/getUserMessagesWithUser");
        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //    var values = JsonConvert.DeserializeObject<List<ResultGetUserMessagesWithUserDto>>(jsonData);
        //    return View(values);
        //}
        return View();
    }
}
