using EntityLayer.Concrete;
using EntityLayer.Dtos.RequestDtos;
using EntityLayer.Dtos.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract;

public interface ISkillService
{
    void Add(SkillCreateRequestDto SkillCreateRequest);
    void Remove(int id);
    void Update(SkillUpdateRequestDto SkillUpdateRequest);
    List<SkillResponseDto> GetAll();
    SkillResponseDto GetById(int id);
}
