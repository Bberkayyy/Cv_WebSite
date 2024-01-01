using EntityLayer.Concrete;
using EntityLayer.Dtos.RequestDtos;
using EntityLayer.Dtos.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract;

public interface IContactService
{
    void Add(ContactCreateRequestDto contactCreateRequest);
    void Remove(int id);
    void Update(ContactUpdateRequestDto contactUpdateRequest);
    List<ContactResponseDto> GetAll();
    ContactResponseDto GetById(int id);
}
