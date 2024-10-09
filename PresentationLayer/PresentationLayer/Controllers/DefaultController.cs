using Dtos.MessageDtos;
using Dtos.TestimonialDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using WebUI.Models;

namespace PresentationLayer.Controllers;

[AllowAnonymous]
public class DefaultController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DefaultController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(CreateMessageDto message)
    {
        var client = _httpClientFactory.CreateClient();
        var jsondata = JsonConvert.SerializeObject(message);

        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7181/api/Messages/add", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index");
        return View();
    }
    [HttpGet]
    public IActionResult Testimonial()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Testimonial(CreateTestimonialViewModel viewModel)
    {
        var client = _httpClientFactory.CreateClient();
        if (viewModel.Picture is not null)
        {
            var resource = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(viewModel.Picture.FileName);
            var imageName = Guid.NewGuid() + extension;
            var saveLocation = resource + "/wwwroot/images/" + imageName;
            var stream = new FileStream(saveLocation, FileMode.Create);
            await viewModel.Picture.CopyToAsync(stream);
            viewModel.ImageUrl = imageName;
        }
        else
        {
            TempData["UnsuccessMessage"] = "Sayfa düzeni için resim seçmeniz gerekmektedir. Lütfen sayfada görünmesi için resminizi seçiniz.";
        }
        var jsonData = JsonConvert.SerializeObject(viewModel);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7181/api/Testimonials/add", content);
        if (responseMessage.IsSuccessStatusCode)
        {
            TempData["SuccessMessage"] = "Teşekkürler. İsteğiniz kısa bir incelemenin ardından sayfaya eklenecektir.";
            return RedirectToAction("Index");
        }
        return View();
    }
}
