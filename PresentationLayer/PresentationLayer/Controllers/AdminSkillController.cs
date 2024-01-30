using Dtos.SkillDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebUI.Controllers;

[Authorize(Roles = "Admin")]
public class AdminSkillController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminSkillController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        ViewBag.v1 = "Yeteneklerim";
        ViewBag.v2 = "Yeteneklerim Tablosu";
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7181/api/Skills/getall");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSkillDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    public IActionResult CreateSkill()
    {
        ViewBag.v1 = "Yeteneklerim";
        ViewBag.v2 = "Yetenek Ekleme Sayfası";
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateSkill(CreateSkillDto createSkillDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createSkillDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7181/api/Skills/add", stringContent);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index");
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> UpdateSkill(int id)
    {
        ViewBag.v1 = "Yeteneklerim";
        ViewBag.v2 = "Yetenek Güncelleme Sayfası";
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7181/api/Skills/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateSkillDto>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> UpdateSkill(UpdateSkillDto updateSkillDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateSkillDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:7181/api/Skills/update", stringContent);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index");
        return View();
    }
    public async Task<IActionResult> RemoveSkill(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"https://localhost:7181/api/Skills/{id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index");
        return View();
    }
}
