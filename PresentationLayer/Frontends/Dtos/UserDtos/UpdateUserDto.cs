using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.UserDtos;

public class UpdateUserDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Mail { get; set; }
    public HashSet<string> Roles { get; set; } = new HashSet<string>();
    public HashSet<string> UserRoles { get; set; } = new HashSet<string>();
}
