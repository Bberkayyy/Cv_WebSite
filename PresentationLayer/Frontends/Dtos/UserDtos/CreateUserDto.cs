using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.UserDtos;

public class CreateUserDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string Mail { get; set; }
}
