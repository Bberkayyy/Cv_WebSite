using Dtos.SocialMediaDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.ViewComponents.FooterViewComponents;

public class _FooterComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _FooterComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseContact = await client.GetAsync("https://localhost:7181/api/SocialMedias/getall");
        if (responseContact.IsSuccessStatusCode)
        {
            var jsonData = await responseContact.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
