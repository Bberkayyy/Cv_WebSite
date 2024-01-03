using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.RequestDtos;

public record class UserMessageCreateRequestDto(string Title,
                                                string Content,
                                                DateTime Date,
                                                bool Status,
                                                int UserId)
{
    public static UserMessage ConverToEntity(UserMessageCreateRequestDto request)
    {
        return new UserMessage
        {
            Title = request.Title,
            Content = request.Content,
            Date = request.Date,
            Status = request.Status,
            UserId = request.UserId
        };
    }
}
