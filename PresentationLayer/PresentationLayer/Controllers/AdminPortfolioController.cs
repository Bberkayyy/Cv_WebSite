﻿using Dtos.PortfolioDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebUI.Controllers;

[Authorize(Roles = "Admin")]
public class AdminPortfolioController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminPortfolioController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        ViewBag.v1 = "Projelerim";
        ViewBag.v2 = "Projelerim Tablosu";
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
    [HttpGet]
    public IActionResult CreatePortfolio()
    {
        ViewBag.v1 = "Projelerim";
        ViewBag.v2 = "Proje Ekleme Sayfası";
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreatePortfolio(CreatePortfolioDto createPortfolioDto)
    {
        var client = _httpClientFactory.CreateClient();
        if (createPortfolioDto.Picture is not null)
        {
            var resource = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(createPortfolioDto.Picture.FileName);
            var imageName = Guid.NewGuid() + extension;
            var saveLocation = resource + "/wwwroot/projectImages/" + imageName;
            var stream = new FileStream(saveLocation, FileMode.Create);
            await createPortfolioDto.Picture.CopyToAsync(stream);
            createPortfolioDto.ProjectImageUrl = imageName;
            createPortfolioDto.ProjectBigImageUrl = imageName;
        }
        var jsonData = JsonConvert.SerializeObject(createPortfolioDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7181/api/Portfolios/add", stringContent);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index");
        TempData["UnsuccessMessage"] = "Sayfa düzeni için proje resmi eklemeniz gerekmektedir. Lütfen sayfada görünmesi için proje resmi ekleyiniz.";
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> UpdatePortfolio(int id)
    {
        ViewBag.v1 = "Projelerim";
        ViewBag.v2 = "Proje Güncelleme Sayfası";
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7181/api/Portfolios/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdatePortfolioDto>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> UpdatePortfolio(UpdatePortfolioDto updatePortfolioDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updatePortfolioDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:7181/api/Portfolios/update", stringContent);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index");
        return View();
    }
    public async Task<IActionResult> RemovePortfolio(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"https://localhost:7181/api/Portfolios/{id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index");
        return View();
    }
}
