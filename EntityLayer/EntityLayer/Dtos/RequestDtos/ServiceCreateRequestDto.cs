using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.RequestDtos;

public record ServiceCreateRequestDto(string Title,
                                      string ImageUrl)
{
    public static Service ConverToEntity(ServiceCreateRequestDto request)
    {
        return new Service
        {
            Title = request.Title,
            ImageUrl = request.ImageUrl,
        };
    }
}
