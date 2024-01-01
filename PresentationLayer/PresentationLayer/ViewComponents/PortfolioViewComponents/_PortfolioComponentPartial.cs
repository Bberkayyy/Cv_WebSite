using Dtos.PortfolioDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.ViewComponents.PortfolioViewComponents;

public class _PortfolioComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _PortfolioComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7181/api/Portfolios/getall");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultPortfolioDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
