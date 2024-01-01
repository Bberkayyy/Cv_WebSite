using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.ResponseDtos;

public record ContactResponseDto(int Id,
                                  string Title,
                                  string Description,
                                  string Mail,
                                  string Phone)
{
    public static ContactResponseDto ConvertToResponse(Contact contact)
    {
        return new ContactResponseDto(
            Id: contact.Id,
            Title: contact.Title,
            Description: contact.Description,
            Mail: contact.Mail,
            Phone: contact.Phone);
    }
}
