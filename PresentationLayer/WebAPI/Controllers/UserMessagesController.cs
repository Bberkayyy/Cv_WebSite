using BusinessLayer.Abstract;
using EntityLayer.Dtos.RequestDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserMessagesController : ControllerBase
{
    private readonly IUserMessageService _UserMessageService;

    public UserMessagesController(IUserMessageService UserMessageService)
    {
        _UserMessageService = UserMessageService;
    }

    [HttpPost("add")]
    public IActionResult Add(UserMessageCreateRequestDto UserMessageCreateRequest)
    {
        _UserMessageService.Add(UserMessageCreateRequest);
        return Ok("Kullanıcı mesajı başarıyla eklendi.");
    }
    [HttpPut("update")]
    public IActionResult Update(UserMessageUpdateRequestDto UserMessageUpdateRequest)
    {
        _UserMessageService.Update(UserMessageUpdateRequest);
        return Ok("Kullanıcı mesajı başarıyla güncellendi.");
    }
    [HttpDelete("{id}")]
    public IActionResult Remove(int id)
    {
        _UserMessageService.Remove(id);
        return Ok("Kullanıcı mesajı başarıyla silindi.");
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var values = _UserMessageService.GetAll();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var value = _UserMessageService.GetById(id);
        return Ok(value);
    }
    [HttpGet("getUserMessagesWithUser")]
    public IActionResult GetUserMessagesWithUser()
    {
        var values = _UserMessageService.GetUserMessagesWithUser();
        return Ok(values);
    }
}
