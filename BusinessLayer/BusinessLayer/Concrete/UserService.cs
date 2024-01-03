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

public class UserService : IUserService
{
    private readonly IUserDal _userDal;

    public UserService(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public void Add(UserCreateRequestDto UserCreateRequest)
    {
        var value = UserCreateRequestDto.ConvertToEntity(UserCreateRequest);
        _userDal.Add(value);
    }

    public List<UserResponseDto> GetAll()
    {
        var values = _userDal.GetAll();
        return values.Select(x => UserResponseDto.ConverToResponse(x)).ToList();
    }

    public UserResponseDto GetById(int id)
    {
        var value = _userDal.GetById(id);
        return UserResponseDto.ConverToResponse(value);
    }

    public void Remove(int id)
    {
        var value = _userDal.GetById(id);
        _userDal.Remove(value);
    }

    public void Update(UserUpdateRequestDto UserUpdateRequest)
    {
        var value = UserUpdateRequestDto.ConverToEntity(UserUpdateRequest);
        _userDal.Update(value);
    }
}
