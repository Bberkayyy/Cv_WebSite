using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.Dtos.RequestDtos;
using EntityLayer.Dtos.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete;

public class ExperianceService : IExperianceService
{
    private readonly IExperianceDal _ExperianceDal;

    public ExperianceService(IExperianceDal ExperianceDal)
    {
        _ExperianceDal = ExperianceDal;
    }

    public void Add(ExperianceCreateRequestDto ExperianceCreateRequest)
    {
        var value = ExperianceCreateRequestDto.ConverToEntity(ExperianceCreateRequest);
        _ExperianceDal.Add(value);
    }

    public List<ExperianceResponseDto> GetAll()
    {
        var values = _ExperianceDal.GetAll();
        return values.Select(x => ExperianceResponseDto.ConvertToResponse(x)).ToList();

    }

    public ExperianceResponseDto GetById(int id)
    {
        var value = _ExperianceDal.GetById(id);
        return ExperianceResponseDto.ConvertToResponse(value);
    }

    public void Remove(int id)
    {
        var value = _ExperianceDal.GetById(id);
        _ExperianceDal.Remove(value);
    }

    public void Update(ExperianceUpdateRequestDto ExperianceUpdateRequest)
    {
        var value = ExperianceUpdateRequestDto.ConverToEntity(ExperianceUpdateRequest);
        _ExperianceDal.Update(value);
    }
}
