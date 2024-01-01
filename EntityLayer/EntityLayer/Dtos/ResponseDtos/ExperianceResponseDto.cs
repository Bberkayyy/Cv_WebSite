using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.ResponseDtos;

public record ExperianceResponseDto(int Id,
                                     string Name,
                                     string Date,
                                     string ImageUrl,
                                     string Description)
{
    public static ExperianceResponseDto ConvertToResponse(Experiance experiance)
    {
        return new ExperianceResponseDto(
            Id: experiance.Id,
            Name: experiance.Name,
            Date: experiance.Date,
            ImageUrl: experiance.ImageUrl,
            Description: experiance.Description);
    }
}
