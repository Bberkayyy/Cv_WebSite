using EntityLayer.Dtos.RequestDtos;
using EntityLayer.Dtos.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract;

public interface IToDoListService
{
    void Add(ToDoListCreateRequestDto ToDoListCreateRequest);
    void Remove(int id);
    void Update(ToDoListUpdateRequestDto ToDoListUpdateRequest);
    List<ToDoListResponseDto> GetAll();
    ToDoListResponseDto GetById(int id);

    void ChangeTodoStatusToTrue(int id);
    void ChangeTodoStatusToFalse(int id);
}
