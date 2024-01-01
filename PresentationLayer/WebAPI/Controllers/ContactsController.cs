using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Dtos.RequestDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactsController : ControllerBase
{
    private readonly IContactService _ContactService;

    public ContactsController(IContactService ContactService)
    {
        _ContactService = ContactService;
    }

    [HttpPost("add")]
    public IActionResult Add(ContactCreateRequestDto ContactCreateRequest)
    {
        _ContactService.Add(ContactCreateRequest);
        return Ok("İletişim bilgisi başarıyla eklendi.");
    }
    [HttpPut("update")]
    public IActionResult Update(ContactUpdateRequestDto ContactUpdateRequest)
    {
        _ContactService.Update(ContactUpdateRequest);
        return Ok("İletişim bilgisi başarıyla güncellendi.");
    }
    [HttpDelete("{id}")]
    public IActionResult Remove(int id)
    {
        _ContactService.Remove(id);
        return Ok("İletişim bilgisi başarıyla silindi.");
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var values = _ContactService.GetAll();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var value = _ContactService.GetById(id);
        return Ok(value);
    }
}
