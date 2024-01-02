using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.RequestDtos;

public record ExperianceCreateRequestDto(string CompanyName,
                                         string TaskName,
                                         string Date,
                                         string Description)
{
    public static Experiance ConverToEntity(ExperianceCreateRequestDto request)
    {
        return new Experiance
        {
            CompanyName = request.CompanyName,
            Date = request.Date,
            TaskName = request.TaskName,
            Description = request.Description,
        };
    }
}
