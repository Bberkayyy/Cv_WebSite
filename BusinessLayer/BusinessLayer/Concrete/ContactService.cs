using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Dtos.RequestDtos;
using EntityLayer.Dtos.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete;

public class ContactService : IContactService
{
    private readonly IContactDal _ContactDal;

    public ContactService(IContactDal ContactDal)
    {
        _ContactDal = ContactDal;
    }

    public void Add(ContactCreateRequestDto ContactCreateRequest)
    {
        var value = ContactCreateRequestDto.ConverToEntity(ContactCreateRequest);
        _ContactDal.Add(value);
    }

    public List<ContactResponseDto> GetAll()
    {
        var values = _ContactDal.GetAll();
        return values.Select(x => ContactResponseDto.ConvertToResponse(x)).ToList();

    }

    public ContactResponseDto GetById(int id)
    {
        var value = _ContactDal.GetById(id);
        return ContactResponseDto.ConvertToResponse(value);
    }

    public void Remove(int id)
    {
        var value = _ContactDal.GetById(id);
        _ContactDal.Remove(value);
    }

    public void Update(ContactUpdateRequestDto ContactUpdateRequest)
    {
        var value = ContactUpdateRequestDto.ConverToEntity(ContactUpdateRequest);
        _ContactDal.Update(value);
    }
}
