using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.RequestDtos;

public record AnnouncementUpdateRequestDto(int Id,
                                           string Title,
                                           DateTime Date,
                                           string Status,
                                           string Content)
{
    public static Announcement ConvertToEntity(AnnouncementUpdateRequestDto announcementUpdateRequestDto)
    {
        return new Announcement
        {
            Content = announcementUpdateRequestDto.Content,
            Status = announcementUpdateRequestDto.Status,
            Title = announcementUpdateRequestDto.Title,
            Id = announcementUpdateRequestDto.Id,
            Date = DateTime.Now
        };
    }
}
