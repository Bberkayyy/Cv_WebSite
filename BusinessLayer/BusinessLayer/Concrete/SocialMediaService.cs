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

public class SocialMediaService : ISocialMediaService
{
    private readonly ISocialMediaDal _SocialMediaDal;

    public SocialMediaService(ISocialMediaDal SocialMediaDal)
    {
        _SocialMediaDal = SocialMediaDal;
    }

    public void Add(SocialMediaCreateRequestDto SocialMediaCreateRequest)
    {
        var value = SocialMediaCreateRequestDto.ConverToEntity(SocialMediaCreateRequest);
        _SocialMediaDal.Add(value);
    }

    public List<SocialMediaResponseDto> GetAll()
    {
        var values = _SocialMediaDal.GetAll();
        return values.Select(x => SocialMediaResponseDto.ConvertToResponse(x)).ToList();

    }

    public SocialMediaResponseDto GetById(int id)
    {
        var value = _SocialMediaDal.GetById(id);
        return SocialMediaResponseDto.ConvertToResponse(value);
    }

    public void Remove(int id)
    {
        var value = _SocialMediaDal.GetById(id);
        _SocialMediaDal.Remove(value);
    }

    public void Update(SocialMediaUpdateRequestDto SocialMediaUpdateRequest)
    {
        var value = SocialMediaUpdateRequestDto.ConverToEntity(SocialMediaUpdateRequest);
        _SocialMediaDal.Update(value);
    }
}
