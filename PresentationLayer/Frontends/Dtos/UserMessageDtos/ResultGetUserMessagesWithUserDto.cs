using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.UserMessageDtos;

public class ResultGetUserMessagesWithUserDto
{
    public int Id { get; init; }
    public string Title { get; init; }
    public string Content { get; init; }
    public DateTime Date { get; init; }
    public bool Status { get; init; }

    public string UserName { get; init; }
    public string UserSurname { get; init; }
    public string UserUserName { get; init; }
    public string UserMail { get; init; }
    public string UserImage { get; init; }
}
