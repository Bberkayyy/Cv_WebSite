using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.ResponseDtos;

public record UserMessageDetailDto
{
    public int Id { get; init; }
    public string Title { get; init; }
    public string Content { get; init; }
    public DateTime Date { get; init; }
    public bool Status { get; init; }

    public string Name { get; init; }
    public string Surname { get; init; }
    public string UserName { get; init; }
    public string Mail { get; init; }
}
