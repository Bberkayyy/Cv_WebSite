using Dtos.ExperianceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.ViewComponents.ExperianceViewComponents;

public class _ExperianceComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _ExperianceComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7181/api/Experiances/getall");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultExperianceDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
