using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.ResponseDtos;

public record ServiceResponseDto(int Id,
                                  string Title,
                                  string ImageUrl)
{
    public static ServiceResponseDto ConvertToResponse(Service Service)
    {
        return new ServiceResponseDto(
            Id: Service.Id,
            Title: Service.Title,
            ImageUrl: Service.ImageUrl
            );
    }
}
