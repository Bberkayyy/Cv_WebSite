using BusinessLayer.Abstract;
using EntityLayer.Dtos.RequestDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeaturesController : ControllerBase
{
    private readonly IFeatureService _FeatureService;

    public FeaturesController(IFeatureService FeatureService)
    {
        _FeatureService = FeatureService;
    }

    [HttpPost("add")]
    public IActionResult Add(FeatureCreateRequestDto FeatureCreateRequest)
    {
        _FeatureService.Add(FeatureCreateRequest);
        return Ok("Özellik başarıyla eklendi.");
    }
    [HttpPut("update")]
    public IActionResult Update(FeatureUpdateRequestDto FeatureUpdateRequest)
    {
        _FeatureService.Update(FeatureUpdateRequest);
        return Ok("Özellik başarıyla güncellendi.");
    }
    [HttpDelete("{id}")]
    public IActionResult Remove(int id)
    {
        _FeatureService.Remove(id);
        return Ok("Özellik başarıyla silindi.");
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var values = _FeatureService.GetAll();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var value = _FeatureService.GetById(id);
        return Ok(value);
    }
}
