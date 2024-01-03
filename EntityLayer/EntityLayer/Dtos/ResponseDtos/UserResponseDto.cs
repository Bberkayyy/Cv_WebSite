using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.ResponseDtos;

public record UserResponseDto(int Id,
                              string Name,
                              string Surname,
                              string UserName,
                              string Mail,
                              string Password,
                              string ImageUrl,
                              bool Status)
{
    public static UserResponseDto ConverToResponse(User user)
    {
        return new UserResponseDto(
            Id: user.Id,
            Name: user.Name,
            Surname: user.Surname,
            UserName: user.UserName,
            Mail: user.Mail,
            Password: user.Password,
            ImageUrl: user.ImageUrl,
            Status: user.Status
            );
    }
}
