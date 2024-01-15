using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.RequestDtos;

public record VisitorMessageUpdateRequestDto(int Id,
                                             string SenderMail,
                                             string ReceiverMail,
                                             string SenderName,
                                             string ReceiverName,
                                             string Subject,
                                             string MessageContent,
                                             DateTime SendDate)
{
    public static VisitorMessage ConvertToEntity(VisitorMessageUpdateRequestDto visitorMessageUpdateRequestDto)
    {
        return new VisitorMessage
        {
            Id = visitorMessageUpdateRequestDto.Id,
            SenderMail = visitorMessageUpdateRequestDto.SenderMail,
            ReceiverMail = visitorMessageUpdateRequestDto.ReceiverMail,
            SenderName = visitorMessageUpdateRequestDto.SenderName,
            ReceiverName = visitorMessageUpdateRequestDto.ReceiverName,
            Subject = visitorMessageUpdateRequestDto.Subject,
            MessageContent = visitorMessageUpdateRequestDto.MessageContent,
            SendDate = visitorMessageUpdateRequestDto.SendDate
        };
    }
}
