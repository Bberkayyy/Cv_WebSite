using BusinessLayer.Abstract;
using EntityLayer.Dtos.RequestDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
    private readonly IMessageService _MessageService;

    public MessagesController(IMessageService MessageService)
    {
        _MessageService = MessageService;
    }

    [HttpPost("add")]
    public IActionResult Add(MessageCreateRequestDto MessageCreateRequest)
    {
        _MessageService.Add(MessageCreateRequest);
        return Ok("Mesaj başarıyla eklendi.");
    }
    [HttpPut("update")]
    public IActionResult Update(MessageUpdateRequestDto MessageUpdateRequest)
    {
        _MessageService.Update(MessageUpdateRequest);
        return Ok("Mesaj başarıyla güncellendi.");
    }
    [HttpDelete("{id}")]
    public IActionResult Remove(int id)
    {
        _MessageService.Remove(id);
        return Ok("Mesaj başarıyla silindi.");
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var values = _MessageService.GetAll();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var value = _MessageService.GetById(id);
        return Ok(value);
    }
    [HttpGet("Last5Messages")]
    public IActionResult GetLast5Messages()
    {
        var value = _MessageService.GetLast5Messages();
        return Ok(value);
    }
}
