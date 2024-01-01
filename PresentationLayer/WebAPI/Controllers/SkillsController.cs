using BusinessLayer.Abstract;
using EntityLayer.Dtos.RequestDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SkillsController : ControllerBase
{
    private readonly ISkillService _SkillService;

    public SkillsController(ISkillService SkillService)
    {
        _SkillService = SkillService;
    }

    [HttpPost("add")]
    public IActionResult Add(SkillCreateRequestDto SkillCreateRequest)
    {
        _SkillService.Add(SkillCreateRequest);
        return Ok("Yetenek başarıyla eklendi.");
    }
    [HttpPut("update")]
    public IActionResult Update(SkillUpdateRequestDto SkillUpdateRequest)
    {
        _SkillService.Update(SkillUpdateRequest);
        return Ok("Yetenek başarıyla güncellendi.");
    }
    [HttpDelete("{id}")]
    public IActionResult Remove(int id)
    {
        _SkillService.Remove(id);
        return Ok("Yetenek başarıyla silindi.");
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var values = _SkillService.GetAll();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var value = _SkillService.GetById(id);
        return Ok(value);
    }
}
