using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.RequestDtos;

public record UserUpdateRequestDto(int Id,
                                   string Name,
                                   string Surname,
                                   string UserName,
                                   string Mail,
                                   string Password,
                                   string ImageUrl,
                                   bool Status)
{
    public static User ConverToEntity(UserUpdateRequestDto request)
    {
        return new User
        {
            Id = request.Id,
            Name = request.Name,
            Surname = request.Surname,
            UserName = request.UserName,
            Mail = request.Mail,
            Password = request.Password,
            ImageUrl = request.ImageUrl,
            Status = request.Status,
        };
    }
}
