using BusinessLayer.Abstract;
using EntityLayer.Dtos.RequestDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SocialMediasController : ControllerBase
{
    private readonly ISocialMediaService _SocialMediaService;

    public SocialMediasController(ISocialMediaService SocialMediaService)
    {
        _SocialMediaService = SocialMediaService;
    }

    [HttpPost("add")]
    public IActionResult Add(SocialMediaCreateRequestDto SocialMediaCreateRequest)
    {
        _SocialMediaService.Add(SocialMediaCreateRequest);
        return Ok("Sosyal medya başarıyla eklendi.");
    }
    [HttpPut("update")]
    public IActionResult Update(SocialMediaUpdateRequestDto SocialMediaUpdateRequest)
    {
        _SocialMediaService.Update(SocialMediaUpdateRequest);
        return Ok("Sosyal medya başarıyla güncellendi.");
    }
    [HttpDelete("{id}")]
    public IActionResult Remove(int id)
    {
        _SocialMediaService.Remove(id);
        return Ok("Sosyal medya başarıyla silindi.");
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var values = _SocialMediaService.GetAll();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var value = _SocialMediaService.GetById(id);
        return Ok(value);
    }
}
