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

public class SkillService : ISkillService
{
    private readonly ISkillDal _SkillDal;

    public SkillService(ISkillDal SkillDal)
    {
        _SkillDal = SkillDal;
    }

    public void Add(SkillCreateRequestDto SkillCreateRequest)
    {
        var value = SkillCreateRequestDto.ConverToEntity(SkillCreateRequest);
        _SkillDal.Add(value);
    }

    public List<SkillResponseDto> GetAll()
    {
        var values = _SkillDal.GetAll();
        return values.Select(x => SkillResponseDto.ConvertToResponse(x)).ToList();

    }

    public SkillResponseDto GetById(int id)
    {
        var value = _SkillDal.GetById(id);
        return SkillResponseDto.ConvertToResponse(value);
    }

    public void Remove(int id)
    {
        var value = _SkillDal.GetById(id);
        _SkillDal.Remove(value);
    }

    public void Update(SkillUpdateRequestDto SkillUpdateRequest)
    {
        var value = SkillUpdateRequestDto.ConverToEntity(SkillUpdateRequest);
        _SkillDal.Update(value);
    }
}
