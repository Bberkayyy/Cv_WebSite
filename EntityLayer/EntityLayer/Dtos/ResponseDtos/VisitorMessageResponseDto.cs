using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.ResponseDtos;

public record VisitorMessageResponseDto(int Id,
                                        string SenderMail,
                                        string ReceiverMail,
                                        string SenderName,
                                        string ReceiverName,
                                        string Subject,
                                        string MessageContent,
                                        DateTime SendDate)
{
    public static VisitorMessageResponseDto ConvertToResponse(VisitorMessage visitorMessage)
    {
        return new VisitorMessageResponseDto(Id: visitorMessage.Id,
                                             SenderMail: visitorMessage.SenderMail,
                                             ReceiverMail: visitorMessage.ReceiverMail,
                                             SenderName: visitorMessage.SenderName,
                                             ReceiverName: visitorMessage.ReceiverName,
                                             Subject: visitorMessage.Subject,
                                             MessageContent: visitorMessage.MessageContent,
                                             SendDate: visitorMessage.SendDate);
    }
}
