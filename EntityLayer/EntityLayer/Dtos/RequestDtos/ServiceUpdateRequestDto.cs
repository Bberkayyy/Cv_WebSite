using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.RequestDtos;

public record ServiceUpdateRequestDto(int Id,
                                      string Title,
                                      string ImageUrl)
{
    public static Service ConverToEntity(ServiceUpdateRequestDto request)
    {
        return new Service
        {
            Id = request.Id,
            Title = request.Title,
            ImageUrl = request.ImageUrl,
        };
    }
}
