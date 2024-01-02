using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.RequestDtos;

public record ExperianceUpdateRequestDto(int Id,
                                         string CompanyName,
                                         string Date,
                                         string TaskName,
                                         string Description)
{
    public static Experiance ConverToEntity(ExperianceUpdateRequestDto request)
    {
        return new Experiance
        {
            Id = request.Id,
            CompanyName = request.CompanyName,
            Date = request.Date,
            TaskName = request.TaskName,
            Description = request.Description,
        };
    }
}
