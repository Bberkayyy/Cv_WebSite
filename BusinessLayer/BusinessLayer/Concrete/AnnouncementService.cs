using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Dtos.RequestDtos;
using EntityLayer.Dtos.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete;

public class AnnouncementService : IAnnouncementService
{
    private readonly IAnnouncementDal _announcementDal;

    public AnnouncementService(IAnnouncementDal announcementDal)
    {
        _announcementDal = announcementDal;
    }

    public void Add(AnnouncementCreateRequestDto announcementCreateRequestDto)
    {
        var value = AnnouncementCreateRequestDto.ConvertToEntity(announcementCreateRequestDto);
        _announcementDal.Add(value);
    }

    public List<AnnouncementResponseDto> GetAll()
    {
        var values = _announcementDal.GetAll();
        return values.Select(x => AnnouncementResponseDto.ConvertToResponse(x)).ToList();
    }

    public AnnouncementResponseDto GetById(int id)
    {
        var value = _announcementDal.GetById(id);
        return AnnouncementResponseDto.ConvertToResponse(value);
    }

    public void Remove(int id)
    {
        var value = _announcementDal.GetById(id);
        _announcementDal.Remove(value);
    }

    public void Update(AnnouncementUpdateRequestDto announcementUpdateRequestDto)
    {
        var value = AnnouncementUpdateRequestDto.ConvertToEntity(announcementUpdateRequestDto);
        _announcementDal.Update(value);
    }
}
