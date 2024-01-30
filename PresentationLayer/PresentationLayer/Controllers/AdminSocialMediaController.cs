using Dtos.SocialMediaDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebUI.Controllers;

[Authorize(Roles = "Admin")]
public class AdminSocialMediaController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminSocialMediaController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        ViewBag.v1 = "Soyal Medya";
        ViewBag.v2 = "Sosyal Medya Hesapları Tablosu";
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7181/api/SocialMedias/getall");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    public IActionResult CreateSocialMedia()
    {
        ViewBag.v1 = "Soyal Medya";
        ViewBag.v2 = "Soyal Medya Hesabı Ekleme Sayfası";
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createSocialMediaDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7181/api/SocialMedias/add", stringContent);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index");
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> UpdateSocialMedia(int id)
    {
        ViewBag.v1 = "Soyal Medya";
        ViewBag.v2 = "Soyal Medya Hesabı Güncelleme Sayfası";
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7181/api/SocialMedias/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateSocialMediaDto>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateSocialMediaDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:7181/api/SocialMedias/update", stringContent);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index");
        return View();
    }
    public async Task<IActionResult> RemoveSocialMedia(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"https://localhost:7181/api/SocialMedias/{id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index");
        return View();
    }
}
