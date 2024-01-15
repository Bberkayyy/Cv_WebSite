using BusinessLayer.Abstract;
using EntityLayer.Dtos.RequestDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VisitorMessagesController : ControllerBase
{
    private readonly IVisitorMessageService _VisitorMessageService;

    public VisitorMessagesController(IVisitorMessageService VisitorMessageService)
    {
        _VisitorMessageService = VisitorMessageService;
    }

    [HttpPost("add")]
    public IActionResult Add(VisitorMessageCreateRequestDto VisitorMessageCreateRequest)
    {
        _VisitorMessageService.Add(VisitorMessageCreateRequest);
        return Ok("Mesaj başarıyla eklendi.");
    }
    [HttpPut("update")]
    public IActionResult Update(VisitorMessageUpdateRequestDto VisitorMessageUpdateRequest)
    {
        _VisitorMessageService.Update(VisitorMessageUpdateRequest);
        return Ok("Mesaj başarıyla güncellendi.");
    }
    [HttpDelete("{id}")]
    public IActionResult Remove(int id)
    {
        _VisitorMessageService.Remove(id);
        return Ok("Mesaj başarıyla silindi.");
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var values = _VisitorMessageService.GetAll();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var value = _VisitorMessageService.GetById(id);
        return Ok(value);
    }
    [HttpGet("getReceiverMessages")]
    public IActionResult GetReceiverMessages(string receiverMail)
    {
        var values = _VisitorMessageService.GetReceiverMessages(receiverMail);
        return Ok(values);
    }
    [HttpGet("getSenderMessages")]
    public IActionResult GetSenderMessages(string senderMail)
    {
        var values = _VisitorMessageService.GetSenderMessages(senderMail);
        return Ok(values);
    }
}
