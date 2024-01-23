using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.ViewComponents.AdminDashboardStatisticsViewComponents;

public class _AdminDashboardStatisticsComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _AdminDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();

        var responseMessageProjectCount = await client.GetAsync("https://localhost:7181/api/Statistics/projectCount");
        if (responseMessageProjectCount.IsSuccessStatusCode)
        {
            var jsonDataProjectCount = await responseMessageProjectCount.Content.ReadAsStringAsync();
            var valueProjectCount = JsonConvert.DeserializeObject<int>(jsonDataProjectCount);
            ViewBag.ProjectCount = valueProjectCount;
        }
        var responseMessageSkillCount = await client.GetAsync("https://localhost:7181/api/Statistics/skillCount");
        if (responseMessageSkillCount.IsSuccessStatusCode)
        {
            var jsonDataSkillCount = await responseMessageSkillCount.Content.ReadAsStringAsync();
            var valueSKillCount = JsonConvert.DeserializeObject<int>(jsonDataSkillCount);
            ViewBag.SkillCount = valueSKillCount;
        }
        var responseMessageUserCount = await client.GetAsync("https://localhost:7181/api/Statistics/userCount");
        if (responseMessageUserCount.IsSuccessStatusCode)
        {
            var jsonDataUserCount = await responseMessageUserCount.Content.ReadAsStringAsync();
            var valueUserCount = JsonConvert.DeserializeObject<int>(jsonDataUserCount);
            ViewBag.UserCount = valueUserCount;
        }
        var responseMessageWebMessageCount = await client.GetAsync("https://localhost:7181/api/Statistics/webMessageCount");
        if (responseMessageWebMessageCount.IsSuccessStatusCode)
        {
            var jsonDataWebMessageCount = await responseMessageWebMessageCount.Content.ReadAsStringAsync();
            var valueWebMessageCount = JsonConvert.DeserializeObject<int>(jsonDataWebMessageCount);
            ViewBag.WebMessageCount = valueWebMessageCount;
        }
        return View();
    }
}
