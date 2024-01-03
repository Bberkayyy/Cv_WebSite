using EntityLayer.Dtos.RequestDtos;
using EntityLayer.Dtos.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract;

public interface IUserService
{
    void Add(UserCreateRequestDto UserCreateRequest);
    void Remove(int id);
    void Update(UserUpdateRequestDto UserUpdateRequest);
    List<UserResponseDto> GetAll();
    UserResponseDto GetById(int id);
}
