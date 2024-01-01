using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.ResponseDtos;

public record SocialMediaResponseDto(int Id,
                                     string Name,
                                     string Url,
                                     string IconUrl,
                                     bool Status)
{
    public static SocialMediaResponseDto ConvertToResponse(SocialMedia SocialMedia)
    {
        return new SocialMediaResponseDto(
            Id: SocialMedia.Id,
            Name: SocialMedia.Name,
            Url: SocialMedia.Url,
            IconUrl: SocialMedia.IconUrl,
            Status: SocialMedia.Status
            );
    }
}
