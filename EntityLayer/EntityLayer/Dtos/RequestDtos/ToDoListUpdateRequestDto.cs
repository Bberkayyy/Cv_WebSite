using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.RequestDtos;

public record ToDoListUpdateRequestDto(int Id,string Content, bool Status)
{
    public static ToDoList ConverToEntity(ToDoListUpdateRequestDto request)
    {
        return new ToDoList
        {
            Id = request.Id,
            Content = request.Content,
            Status = request.Status,
        };
    }
}