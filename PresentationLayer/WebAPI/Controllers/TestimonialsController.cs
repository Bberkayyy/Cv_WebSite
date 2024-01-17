using BusinessLayer.Abstract;
using EntityLayer.Dtos.RequestDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestimonialsController : ControllerBase
{
    private readonly ITestimonialService _TestimonialService;

    public TestimonialsController(ITestimonialService TestimonialService)
    {
        _TestimonialService = TestimonialService;
    }

    [HttpPost("add")]
    public IActionResult Add(TestimonialCreateRequestDto TestimonialCreateRequest)
    {
        _TestimonialService.Add(TestimonialCreateRequest);
        return Ok("Referans başarıyla eklendi.");
    }
    [HttpPut("update")]
    public IActionResult Update(TestimonialUpdateRequestDto TestimonialUpdateRequest)
    {
        _TestimonialService.Update(TestimonialUpdateRequest);
        return Ok("Referans başarıyla güncellendi.");
    }
    [HttpDelete("{id}")]
    public IActionResult Remove(int id)
    {
        _TestimonialService.Remove(id);
        return Ok("Referans başarıyla silindi.");
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var values = _TestimonialService.GetAll();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var value = _TestimonialService.GetById(id);
        return Ok(value);
    }
    [HttpGet("TestimonialShowcaseToFalse")]
    public IActionResult ChangeTestimonialShowcaseToFalse(int id)
    {
        _TestimonialService.ChangeTestimonialShowcaseToFalse(id);
        return Ok("Güncelleme Başarılı");
    }
    [HttpGet("TestimonialShowcaseToTrue")]
    public IActionResult ChangeTestimonialShowcaseToTrue(int id)
    {
        _TestimonialService.ChangeTestimonialShowcaseToTrue(id);
        return Ok("Güncelleme Başarılı");
    }
}
