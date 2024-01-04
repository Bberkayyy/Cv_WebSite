using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Dtos.RequestDtos;
using EntityLayer.Dtos.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete;

public class ToDoListService : IToDoListService
{
    private readonly IToDoListDal _ToDoListDal;

    public ToDoListService(IToDoListDal ToDoListDal)
    {
        _ToDoListDal = ToDoListDal;
    }

    public void Add(ToDoListCreateRequestDto ToDoListCreateRequest)
    {
        var value = ToDoListCreateRequestDto.ConverToEntity(ToDoListCreateRequest);
        _ToDoListDal.Add(value);
    }

    public List<ToDoListResponseDto> GetAll()
    {
        var values = _ToDoListDal.GetAll();
        return values.Select(x => ToDoListResponseDto.ConvertToResponse(x)).ToList();

    }

    public ToDoListResponseDto GetById(int id)
    {
        var value = _ToDoListDal.GetById(id);
        return ToDoListResponseDto.ConvertToResponse(value);
    }

    public void Remove(int id)
    {
        var value = _ToDoListDal.GetById(id);
        _ToDoListDal.Remove(value);
    }

    public void Update(ToDoListUpdateRequestDto ToDoListUpdateRequest)
    {
        var value = ToDoListUpdateRequestDto.ConverToEntity(ToDoListUpdateRequest);
        _ToDoListDal.Update(value);
    }
}
