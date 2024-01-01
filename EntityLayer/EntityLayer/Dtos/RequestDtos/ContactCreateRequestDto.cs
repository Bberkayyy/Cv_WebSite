using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.RequestDtos;

public record ContactCreateRequestDto(string Title,
                                      string Description,
                                      string Mail,
                                      string Phone)
{
    public static Contact ConverToEntity(ContactCreateRequestDto request)
    {
        return new Contact
        {
            Title = request.Title,
            Description = request.Description,
            Mail = request.Mail,
            Phone = request.Phone
        };
    }
}
