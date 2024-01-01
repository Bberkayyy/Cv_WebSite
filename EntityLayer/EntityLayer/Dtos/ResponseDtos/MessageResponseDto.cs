using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.ResponseDtos;

public record MessageResponseDto(int Id,
                                  string Name,
                                  string Mail,
                                  string Content,
                                  DateTime Date,
                                  bool Status)
{
    public static MessageResponseDto ConvertToResponse(Message Message)
    {
        return new MessageResponseDto(
            Id: Message.Id,
            Name: Message.Name,
            Mail: Message.Mail,
            Content: Message.Content,
            Date: Message.Date,
            Status: Message.Status
            );
    }
}
