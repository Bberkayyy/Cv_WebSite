using Dtos.FeatureDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebUI.Controllers;

[Authorize(Roles = "Admin")]
public class AdminFeatureController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminFeatureController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        ViewBag.v1 = "AnaSayfa";
        ViewBag.v2 = "Anasayfa Veri Tablosu";
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7181/api/Features/getall");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    public IActionResult CreateFeature()
    {
        ViewBag.v1 = "AnaSayfa";
        ViewBag.v2 = "AnaSayfa Veri Ekleme Sayfası";
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createFeatureDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7181/api/Features/add", stringContent);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index");
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> UpdateFeature(int id)
    {
        ViewBag.v1 = "AnaSayfa";
        ViewBag.v2 = "AnaSayfa Veri Güncelleme Sayfası";
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7181/api/Features/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateFeatureDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:7181/api/Features/update", stringContent);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index");
        return View();
    }
    public async Task<IActionResult> RemoveFeature(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"https://localhost:7181/api/Features/{id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index");
        return View();
    }
}
