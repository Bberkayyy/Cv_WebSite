using EntityLayer.Concrete;
using EntityLayer.Dtos.RequestDtos;
using EntityLayer.Dtos.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract;

public interface IMessageService
{
    void Add(MessageCreateRequestDto MessageCreateRequest);
    void Remove(int id);
    void Update(MessageUpdateRequestDto MessageUpdateRequest);
    List<MessageResponseDto> GetAll();
    MessageResponseDto GetById(int id);

    List<MessageResponseDto> GetLast5Messages();
    void ChangeMessageStatusToFalse(int id);
    void ChangeMessageStatusToTrue(int id);
}
