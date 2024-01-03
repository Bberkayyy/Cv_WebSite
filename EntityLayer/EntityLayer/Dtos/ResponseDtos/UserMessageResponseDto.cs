using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.ResponseDtos;

public record UserMessageResponseDto(int Id,
                                     string Title,
                                     string Content,
                                     DateTime Date,
                                     bool Status,
                                     int UserId)
{
    public static UserMessageResponseDto ConverToResponse(UserMessage userMessage)
    {
        return new UserMessageResponseDto(
            Id: userMessage.Id,
            Title: userMessage.Title,
            Content: userMessage.Content,
            Date: userMessage.Date,
            Status: userMessage.Status,
            UserId: userMessage.UserId
            );
    }
}
