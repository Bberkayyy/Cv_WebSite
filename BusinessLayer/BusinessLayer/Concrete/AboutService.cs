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

public class AboutService : IAboutService
{
    private readonly IAboutDal _aboutDal;

    public AboutService(IAboutDal aboutDal)
    {
        _aboutDal = aboutDal;
    }

    public void Add(AboutCreateRequestDto aboutCreateRequest)
    {
        var value = AboutCreateRequestDto.ConverToEntity(aboutCreateRequest);
        _aboutDal.Add(value);
    }

    public List<AboutResponseDto> GetAll()
    {
        var values = _aboutDal.GetAll();
        return values.Select(x => AboutResponseDto.ConvertToResponse(x)).ToList();

    }

    public AboutResponseDto GetById(int id)
    {
        var value = _aboutDal.GetById(id);
        return AboutResponseDto.ConvertToResponse(value);
    }

    public void Remove(int id)
    {
        var value = _aboutDal.GetById(id);
        _aboutDal.Remove(value);
    }

    public void Update(AboutUpdateRequestDto aboutUpdateRequest)
    {
        var value = AboutUpdateRequestDto.ConverToEntity(aboutUpdateRequest);
        _aboutDal.Update(value);
    }
}
