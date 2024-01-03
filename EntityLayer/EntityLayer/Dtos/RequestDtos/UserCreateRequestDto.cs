using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.RequestDtos;

public record UserCreateRequestDto(string Name,
                                  string Surname,
                                  string UserName,
                                  string Mail,
                                  string Password,
                                  string ImageUrl,
                                  bool Status)
{
    public static User ConvertToEntity(UserCreateRequestDto request)
    {
        return new User
        {
            Name = request.Name,
            Surname = request.Surname,
            UserName = request.UserName,
            Mail = request.Mail,
            Password = request.Password,
            ImageUrl = request.ImageUrl,
            Status = request.Status
        };
    }
}
