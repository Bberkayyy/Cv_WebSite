using Dtos.TestimonialDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebUI.Controllers;
[Authorize]
public class AdminTestimonialController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminTestimonialController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.v1 = "Referanslar";
        ViewBag.v2 = "Referans İstekleri";
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7181/api/Testimonials/getall");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
            var orderList = values.OrderByDescending(x => x.Showcase).ToList();
            return View(orderList);
        }
        return View();
    }
    [HttpGet]
    public IActionResult CreateTestimonial()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createTestimonialDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7181/api/Testimonials/add", stringContent);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index");
        return View();
    }

    public async Task<IActionResult> RemoveTestimonial(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"https://localhost:7181/api/Testimonials/{id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index");
        return View();
    }
    [HttpGet]
    [HttpPost]
    public async Task<IActionResult> UpdateTestimonialStatus(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var getResponseMessage = await client.GetAsync("https://localhost:7181/api/Testimonials/" + id);
        var getData = await getResponseMessage.Content.ReadAsStringAsync();
        var updateData = JsonConvert.DeserializeObject<UpdateTestimonialDto>(getData);
        if (updateData.Showcase)
        {
            await client.GetAsync($"https://localhost:7181/api/Testimonials/TestimonialShowcaseToFalse?id=" + id);
        }
        else
        {
            await client.GetAsync($"https://localhost:7181/api/Testimonials/TestimonialShowcaseToTrue?id=" + id);
        }
        return RedirectToAction("Index");
    }
    [HttpGet]
    public async Task<IActionResult> UpdateTestimonialContent(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7181/api/Testimonials/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateTestimonialDto>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> UpdateTestimonialContent(UpdateTestimonialDto updateTestimonialDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateTestimonialDto);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:7181/api/Testimonials/update", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index");
        return View();
    }
}
