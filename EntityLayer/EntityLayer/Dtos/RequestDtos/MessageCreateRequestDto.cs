using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.RequestDtos;

public record MessageCreateRequestDto(string Name,
                                      string Mail,
                                      string Content,
                                      DateTime Date,
                                      bool Status)
{
    public static Message ConverToEntity(MessageCreateRequestDto request)
    {
        return new Message
        {
            Name = request.Name,
            Mail = request.Mail,
            Content = request.Content,
            Date = request.Date,
            Status = request.Status
        };
    }
}
