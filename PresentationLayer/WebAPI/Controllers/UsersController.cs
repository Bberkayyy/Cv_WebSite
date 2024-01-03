using BusinessLayer.Abstract;
using EntityLayer.Dtos.RequestDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _UserService;

    public UsersController(IUserService UserService)
    {
        _UserService = UserService;
    }

    [HttpPost("add")]
    public IActionResult Add(UserCreateRequestDto UserCreateRequest)
    {
        _UserService.Add(UserCreateRequest);
        return Ok("Kullanıcı başarıyla eklendi.");
    }
    [HttpPut("update")]
    public IActionResult Update(UserUpdateRequestDto UserUpdateRequest)
    {
        _UserService.Update(UserUpdateRequest);
        return Ok("Kullanıcı başarıyla güncellendi.");
    }
    [HttpDelete("{id}")]
    public IActionResult Remove(int id)
    {
        _UserService.Remove(id);
        return Ok("Kullanıcı başarıyla silindi.");
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var values = _UserService.GetAll();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var value = _UserService.GetById(id);
        return Ok(value);
    }
}
