using BusinessLayer.Abstract;
using EntityLayer.Dtos.RequestDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ToDoListsController : ControllerBase
{
    private readonly IToDoListService _ToDoListService;

    public ToDoListsController(IToDoListService ToDoListService)
    {
        _ToDoListService = ToDoListService;
    }

    [HttpPost("add")]
    public IActionResult Add(ToDoListCreateRequestDto ToDoListCreateRequest)
    {
        _ToDoListService.Add(ToDoListCreateRequest);
        return Ok("Yapılacaklar başarıyla eklendi.");
    }
    [HttpPut("update")]
    public IActionResult Update(ToDoListUpdateRequestDto ToDoListUpdateRequest)
    {
        _ToDoListService.Update(ToDoListUpdateRequest);
        return Ok("Yapılacaklar başarıyla güncellendi.");
    }
    [HttpDelete("{id}")]
    public IActionResult Remove(int id)
    {
        _ToDoListService.Remove(id);
        return Ok("Yapılacaklar başarıyla silindi.");
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var values = _ToDoListService.GetAll();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var value = _ToDoListService.GetById(id);
        return Ok(value);
    }
    [HttpGet("TodoStatusToTrue")]
    public IActionResult ChangeTodoStatusToTrue(int id)
    {
        _ToDoListService.ChangeTodoStatusToTrue(id);
        return Ok("Güncelleme Başarılı.");
    }
    [HttpGet("TodoStatusToFalse")]
    public IActionResult ChangeTodoStatusToFalse(int id)
    {
        _ToDoListService.ChangeTodoStatusToFalse(id);
        return Ok("Güncelleme Başarılı.");
    }
}
