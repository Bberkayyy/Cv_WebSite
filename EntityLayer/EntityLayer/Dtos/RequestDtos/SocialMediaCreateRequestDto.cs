using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.RequestDtos;

public record SocialMediaCreateRequestDto(string Name,
                                          string Url,
                                          string IconUrl,
                                         bool Status)
{
    public static SocialMedia ConverToEntity(SocialMediaCreateRequestDto request)
    {
        return new SocialMedia
        {
            Name = request.Name,
            Url = request.Url,
            IconUrl = request.IconUrl,
            Status = request.Status
        };
    }
}
