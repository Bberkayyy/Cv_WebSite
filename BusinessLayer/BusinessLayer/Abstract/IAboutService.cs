using EntityLayer.Dtos.RequestDtos;
using EntityLayer.Dtos.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract;

public interface IAboutService
{
    void Add(AboutCreateRequestDto aboutCreateRequest);
    void Remove(int id);
    void Update(AboutUpdateRequestDto aboutUpdateRequest);
    List<AboutResponseDto> GetAll();
    AboutResponseDto GetById(int id);
}
