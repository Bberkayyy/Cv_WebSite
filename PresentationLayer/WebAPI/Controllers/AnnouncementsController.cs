using BusinessLayer.Abstract;
using EntityLayer.Dtos.RequestDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnnouncementsController : ControllerBase
{
    private readonly IAnnouncementService _AnnouncementService;

    public AnnouncementsController(IAnnouncementService AnnouncementService)
    {
        _AnnouncementService = AnnouncementService;
    }

    [HttpPost("add")]
    public IActionResult Add(AnnouncementCreateRequestDto AnnouncementCreateRequest)
    {
        _AnnouncementService.Add(AnnouncementCreateRequest);
        return Ok("Duyuru başarıyla eklendi.");
    }
    [HttpPut("update")]
    public IActionResult Update(AnnouncementUpdateRequestDto AnnouncementUpdateRequest)
    {
        _AnnouncementService.Update(AnnouncementUpdateRequest);
        return Ok("Duyuru başarıyla güncellendi.");
    }
    [HttpDelete("{id}")]
    public IActionResult Remove(int id)
    {
        _AnnouncementService.Remove(id);
        return Ok("Duyuru başarıyla silindi.");
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var values = _AnnouncementService.GetAll();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var value = _AnnouncementService.GetById(id);
        return Ok(value);
    }
}
