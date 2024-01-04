using EntityLayer.Concrete;
using EntityLayer.Dtos.RequestDtos;
using EntityLayer.Dtos.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract;

public interface IUserMessageService
{
    void Add(UserMessageCreateRequestDto UserMessageCreateRequest);
    void Remove(int id);
    void Update(UserMessageUpdateRequestDto UserMessageUpdateRequest);
    List<UserMessageResponseDto> GetAll();
    UserMessageResponseDto GetById(int id);
    List<UserMessageDetailDto> GetUserMessagesWithUser();
}
