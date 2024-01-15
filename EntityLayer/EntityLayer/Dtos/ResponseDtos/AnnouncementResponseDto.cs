using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.ResponseDtos;

public record AnnouncementResponseDto(int Id,
                                      string Title,
                                      DateTime Date,
                                      string Status,
                                      string Content)
{
    public static AnnouncementResponseDto ConvertToResponse(Announcement announcement)
    {
        return new AnnouncementResponseDto(Id: announcement.Id,
                                           Title: announcement.Title,
                                           Date: announcement.Date,
                                           Status: announcement.Status,
                                           Content: announcement.Content);
    }
}
