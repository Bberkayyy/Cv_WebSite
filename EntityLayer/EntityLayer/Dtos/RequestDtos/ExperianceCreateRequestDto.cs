using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.RequestDtos;

public record ExperianceCreateRequestDto(string Name,
                                         string Date,
                                         string ImageUrl,
                                         string Description)
{
    public static Experiance ConverToEntity(ExperianceCreateRequestDto request)
    {
        return new Experiance
        {
            Name = request.Name,
            Date = request.Date,
            ImageUrl = request.ImageUrl,
            Description = request.Description,
        };
    }
}
