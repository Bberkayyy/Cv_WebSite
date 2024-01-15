using EntityLayer.Concrete;
using EntityLayer.Dtos.RequestDtos;
using EntityLayer.Dtos.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract;

public interface IAnnouncementService
{
    void Add(AnnouncementCreateRequestDto announcementCreateRequestDto);
    void Update(AnnouncementUpdateRequestDto announcementUpdateRequestDto);
    void Remove(int id);
    List<AnnouncementResponseDto> GetAll();
    AnnouncementResponseDto GetById(int id);
}
