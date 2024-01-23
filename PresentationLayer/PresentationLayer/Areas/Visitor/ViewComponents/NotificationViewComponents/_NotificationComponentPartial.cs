using Dtos.AnnouncementDtos;
using Dtos.VisitorMessageDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Areas.Visitor.ViewComponents.NotificationViewComponents;

public class _NotificationComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly UserManager<VisitorUser> _userManager;

    public _NotificationComponentPartial(IHttpClientFactory httpClientFactory, UserManager<VisitorUser> userManager)
    {
        _httpClientFactory = httpClientFactory;
        _userManager = userManager;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        var mail = user.Email;
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
}
