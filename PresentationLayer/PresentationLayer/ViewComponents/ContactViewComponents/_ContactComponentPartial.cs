using Dtos.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.ViewComponents.ContactViewComponents;

public class _ContactComponentPartial:ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _ContactComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseContact = await client.GetAsync("https://localhost:7181/api/Contacts/getall");
        if (responseContact.IsSuccessStatusCode)
        {
            var jsonData = await responseContact.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
