using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.RequestDtos;

public record UserMessageUpdateRequestDto(int Id,
                                          string Title,
                                          string Content,
                                          DateTime Date,
                                          bool Status,
                                          int UserId)
{
    public static UserMessage ConverToEntity(UserMessageUpdateRequestDto request)
    {
        return new UserMessage
        {
            Id = request.Id,
            Title = request.Title,
            Content = request.Content,
            Date = request.Date,
            Status = request.Status,
            UserId = request.UserId
        };
    }
}
