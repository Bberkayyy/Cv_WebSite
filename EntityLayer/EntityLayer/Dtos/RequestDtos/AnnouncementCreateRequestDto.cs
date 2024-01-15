using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.RequestDtos;

public record AnnouncementCreateRequestDto(string Title,
                                           DateTime Date,
                                           string Status,
                                           string Content)
{
    public static Announcement ConvertToEntity(AnnouncementCreateRequestDto requestDto)
    {
        return new Announcement
        {
            Content = requestDto.Content,
            Title = requestDto.Title,
            Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
            Status = requestDto.Status,
        };
    }
}