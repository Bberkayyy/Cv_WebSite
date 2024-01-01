using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Dtos.RequestDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AboutsController : ControllerBase
{
    private readonly IAboutService _aboutService;

    public AboutsController(IAboutService aboutService)
    {
        _aboutService = aboutService;
    }

    [HttpPost("add")]
    public IActionResult Add(AboutCreateRequestDto aboutCreateRequest)
    {
        _aboutService.Add(aboutCreateRequest);
        return Ok("Hakkımda başarıyla eklendi.");
    }
    [HttpPut("update")]
    public IActionResult Update(AboutUpdateRequestDto aboutUpdateRequest)
    {
        _aboutService.Update(aboutUpdateRequest);
        return Ok("Hakkımda başarıyla güncellendi.");
    }
    [HttpDelete("{id}")]
    public IActionResult Remove(int id)
    {
        _aboutService.Remove(id);
        return Ok("Hakkımda başarıyla silindi.");
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var values = _aboutService.GetAll();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var value = _aboutService.GetById(id);
        return Ok(value);
    }
}
