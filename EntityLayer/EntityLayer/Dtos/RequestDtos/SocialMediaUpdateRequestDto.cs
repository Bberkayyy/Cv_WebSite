using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.RequestDtos;

public record SocialMediaUpdateRequestDto(int Id,
                                          string Name,
                                          string Url,
                                          string IconUrl,
                                          bool Status)
{
    public static SocialMedia ConverToEntity(SocialMediaUpdateRequestDto request)
    {
        return new SocialMedia
        {
            Id = request.Id,
            Name = request.Name,
            Url = request.Url,
            IconUrl = request.IconUrl,
            Status = request.Status
        };
    }
}
