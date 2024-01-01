using BusinessLayer.Abstract;
using EntityLayer.Dtos.RequestDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExperiancesController : ControllerBase
{
    private readonly IExperianceService _ExperianceService;

    public ExperiancesController(IExperianceService ExperianceService)
    {
        _ExperianceService = ExperianceService;
    }

    [HttpPost("add")]
    public IActionResult Add(ExperianceCreateRequestDto ExperianceCreateRequest)
    {
        _ExperianceService.Add(ExperianceCreateRequest);
        return Ok("Deneyim başarıyla eklendi.");
    }
    [HttpPut("update")]
    public IActionResult Update(ExperianceUpdateRequestDto ExperianceUpdateRequest)
    {
        _ExperianceService.Update(ExperianceUpdateRequest);
        return Ok("Deneyim başarıyla güncellendi.");
    }
    [HttpDelete("{id}")]
    public IActionResult Remove(int id)
    {
        _ExperianceService.Remove(id);
        return Ok("Deneyim başarıyla silindi.");
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var values = _ExperianceService.GetAll();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var value = _ExperianceService.GetById(id);
        return Ok(value);
    }
}
