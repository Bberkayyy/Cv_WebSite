using EntityLayer.Concrete;
using EntityLayer.Dtos.RequestDtos;
using EntityLayer.Dtos.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract;

public interface IExperianceService
{
    void Add(ExperianceCreateRequestDto ExperianceCreateRequest);
    void Remove(int id);
    void Update(ExperianceUpdateRequestDto ExperianceUpdateRequest);
    List<ExperianceResponseDto> GetAll();
    ExperianceResponseDto GetById(int id);
}
