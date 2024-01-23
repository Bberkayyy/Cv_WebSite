using Dtos.TestimonialDtos;
using Dtos.ToDoListDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebUI.Controllers;

public class AdminDashboardToDoListController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminDashboardToDoListController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public IActionResult CreateToDo()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateToDo(CreateTodoDto createTodoDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(createTodoDto);
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:7181/api/ToDoLists/add", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "AdminDashboard");
        return RedirectToAction("Index", "AdminDashboard");
    }
    public async Task<IActionResult> RemoveToDo(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"https://localhost:7181/api/ToDoLists/{id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "AdminDashboard");
        return RedirectToAction("Index", "AdminDashboard");
    }
    [HttpGet]
    [HttpPost]
    public async Task<IActionResult> UpdateToDoStatus(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var getResponseMessage = await client.GetAsync("https://localhost:7181/api/ToDoLists/" + id);
        var getData = await getResponseMessage.Content.ReadAsStringAsync();
        var updateData = JsonConvert.DeserializeObject<UpdateTodoDto>(getData);
        if (updateData.Status)
            await client.GetAsync("https://localhost:7181/api/ToDoLists/TodoStatusToFalse?id=" + id);
        else
            await client.GetAsync("https://localhost:7181/api/ToDoLists/TodoStatusToTrue?id=" + id);
        return RedirectToAction("Index", "AdminDashboard");
    }
}
