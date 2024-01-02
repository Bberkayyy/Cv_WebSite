using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.ResponseDtos;

public record ExperianceResponseDto(int Id,
                                     string CompanyName,
                                     string Date,
                                     string TaskName,
                                     string Description)
{
    public static ExperianceResponseDto ConvertToResponse(Experiance experiance)
    {
        return new ExperianceResponseDto(
            Id: experiance.Id,
            CompanyName: experiance.CompanyName,
            Date: experiance.Date,
            TaskName: experiance.TaskName,
            Description: experiance.Description);
    }
}
