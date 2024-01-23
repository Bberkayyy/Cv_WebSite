using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatisticsController : ControllerBase
{
    private readonly IStatisticService _statisticService;

    public StatisticsController(IStatisticService statisticService)
    {
        _statisticService = statisticService;
    }

    [HttpGet("projectCount")]
    public IActionResult ProjectCount()
    {
        var value = _statisticService.GetProjectCount();
        return Ok(value);
    }
    [HttpGet("skillCount")]
    public IActionResult SkillCount()
    {
        var value = _statisticService.GetSkillCount();
        return Ok(value);
    }
    [HttpGet("userCount")]
    public IActionResult UserCount()
    {
        var value = _statisticService.GetUserCount();
        return Ok(value);
    }
    [HttpGet("webMessageCount")]
    public IActionResult WebMessageCount()
    {
        var value = _statisticService.GetWebMessageCount();
        return Ok(value);
    }
}
