using BusinessLayer.Abstract;
using EntityLayer.Dtos.RequestDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServicesController : ControllerBase
{
    private readonly IServiceService _ServiceService;

    public ServicesController(IServiceService ServiceService)
    {
        _ServiceService = ServiceService;
    }

    [HttpPost("add")]
    public IActionResult Add(ServiceCreateRequestDto ServiceCreateRequest)
    {
        _ServiceService.Add(ServiceCreateRequest);
        return Ok("Hizmet başarıyla eklendi.");
    }
    [HttpPut("update")]
    public IActionResult Update(ServiceUpdateRequestDto ServiceUpdateRequest)
    {
        _ServiceService.Update(ServiceUpdateRequest);
        return Ok("Hizmet başarıyla güncellendi.");
    }
    [HttpDelete("{id}")]
    public IActionResult Remove(int id)
    {
        _ServiceService.Remove(id);
        return Ok("Hizmet başarıyla silindi.");
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var values = _ServiceService.GetAll();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var value = _ServiceService.GetById(id);
        return Ok(value);
    }
}
