using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.RequestDtos;

public record AboutUpdateRequestDto(int Id,
                                    string Title,
                                    string Description,
                                    string Age,
                                    string Mail,
                                    string Phone,
                                    string Address,
                                    string ImageUrl)
{
    public static About ConverToEntity(AboutUpdateRequestDto request)
    {
        return new About
        {
            Id = request.Id,
            Title = request.Title,
            Description = request.Description,
            Age = request.Age,
            Mail = request.Mail,
            Phone = request.Phone,
            Address = request.Address,
            ImageUrl = request.ImageUrl
        };
    }

}
