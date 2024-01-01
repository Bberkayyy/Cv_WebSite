using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.RequestDtos;

public record ContactUpdateRequestDto(int Id,
                                      string Title,
                                      string Description,
                                      string Mail,
                                      string Phone)
{
    public static Contact ConverToEntity(ContactUpdateRequestDto request)
    {
        return new Contact
        {
            Id = request.Id,
            Title = request.Title,
            Description = request.Description,
            Mail = request.Mail,
            Phone = request.Phone
        };
    }
}
