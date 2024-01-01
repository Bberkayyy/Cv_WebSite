using BusinessLayer.Abstract;
using EntityLayer.Dtos.RequestDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PortfoliosController : ControllerBase
{
    private readonly IPortfolioService _PortfolioService;

    public PortfoliosController(IPortfolioService PortfolioService)
    {
        _PortfolioService = PortfolioService;
    }

    [HttpPost("add")]
    public IActionResult Add(PortfolioCreateRequestDto PortfolioCreateRequest)
    {
        _PortfolioService.Add(PortfolioCreateRequest);
        return Ok("Portföy başarıyla eklendi.");
    }
    [HttpPut("update")]
    public IActionResult Update(PortfolioUpdateRequestDto PortfolioUpdateRequest)
    {
        _PortfolioService.Update(PortfolioUpdateRequest);
        return Ok("Portföy başarıyla güncellendi.");
    }
    [HttpDelete("{id}")]
    public IActionResult Remove(int id)
    {
        _PortfolioService.Remove(id);
        return Ok("Portföy başarıyla silindi.");
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var values = _PortfolioService.GetAll();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var value = _PortfolioService.GetById(id);
        return Ok(value);
    }
}
