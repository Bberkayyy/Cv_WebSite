using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.RequestDtos;

public record ToDoListCreateRequestDto(string Content, bool Status)
{
    public static ToDoList ConverToEntity(ToDoListCreateRequestDto request)
    {
        return new ToDoList
        {
            Content = request.Content,
            Status = request.Status,
        };
    }
}
