using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.RequestDtos;

public record VisitorMessageCreateRequestDto(string SenderMail,
                                             string ReceiverMail,
                                             string SenderName,
                                             string ReceiverName,
                                             string Subject,
                                             string MessageContent,
                                             DateTime SendDate)
{
    public static VisitorMessage ConvertToEntity(VisitorMessageCreateRequestDto visitorMessageCreateRequestDto)
    {
        return new VisitorMessage
        {
            SenderMail = visitorMessageCreateRequestDto.SenderMail,
            ReceiverMail = visitorMessageCreateRequestDto.ReceiverMail,
            SenderName = visitorMessageCreateRequestDto.SenderName,
            ReceiverName = visitorMessageCreateRequestDto.ReceiverName,
            Subject = visitorMessageCreateRequestDto.Subject,
            MessageContent = visitorMessageCreateRequestDto.MessageContent,
            SendDate = visitorMessageCreateRequestDto.SendDate
        };
    }
}
