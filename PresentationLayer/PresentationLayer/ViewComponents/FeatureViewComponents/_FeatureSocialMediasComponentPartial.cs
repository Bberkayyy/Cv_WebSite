using Dtos.SocialMediaDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.ViewComponents.FeatureViewComponents;

public class _FeatureSocialMediasComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _FeatureSocialMediasComponentPartial(IHttpClientFactory httpClientFactory)
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
