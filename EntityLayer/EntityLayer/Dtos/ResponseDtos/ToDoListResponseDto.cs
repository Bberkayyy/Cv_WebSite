using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.ResponseDtos;

public record ToDoListResponseDto(int Id, string Content, bool Status)
{
    public static ToDoListResponseDto ConvertToResponse(ToDoList toDoList)
    {
        return new ToDoListResponseDto(
            Id: toDoList.Id,
            Content: toDoList.Content,
            Status: toDoList.Status);

    }
}
