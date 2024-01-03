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

public class UserMessageService : IUserMessageService
{
    private readonly IUserMessageDal _userMessageDal;

    public UserMessageService(IUserMessageDal userMessageDal)
    {
        _userMessageDal = userMessageDal;
    }

    public void Add(UserMessageCreateRequestDto UserMessageCreateRequest)
    {
        var value = UserMessageCreateRequestDto.ConverToEntity(UserMessageCreateRequest);
        _userMessageDal.Add(value);
    }

    public List<UserMessageResponseDto> GetAll()
    {
        var values = _userMessageDal.GetAll();
        return values.Select(x => UserMessageResponseDto.ConverToResponse(x)).ToList();
    }

    public UserMessageResponseDto GetById(int id)
    {
        var value = _userMessageDal.GetById(id);
        return UserMessageResponseDto.ConverToResponse(value);
    }

    public List<UserMessageDetailDto> GetUserMessagesWithUser()
    {
        var values = _userMessageDal.GetUserMessagesWithUser();
        return values;
    }

    public void Remove(int id)
    {
        var value = _userMessageDal.GetById(id);
        _userMessageDal.Remove(value);
    }

    public void Update(UserMessageUpdateRequestDto UserMessageUpdateRequest)
    {
        var value = UserMessageUpdateRequestDto.ConverToEntity(UserMessageUpdateRequest);
        _userMessageDal.Update(value);
    }
}
