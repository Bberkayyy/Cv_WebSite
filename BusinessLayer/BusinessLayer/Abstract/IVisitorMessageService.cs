using EntityLayer.Concrete;
using EntityLayer.Dtos;
using EntityLayer.Dtos.RequestDtos;
using EntityLayer.Dtos.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract;

public interface IVisitorMessageService
{
    void Add(VisitorMessageCreateRequestDto VisitorMessageCreateRequest);
    void Remove(int id);
    void Update(VisitorMessageUpdateRequestDto VisitorMessageUpdateRequest);
    List<VisitorMessageResponseDto> GetAll();
    VisitorMessageResponseDto GetById(int id);


    List<VisitorMessageResponseDto> GetReceiverMessages(string mail);
    List<VisitorMessageResponseDto> GetSenderMessages(string mail);
    int GetReceiverMessageCount(string mail);
    int GetSenderMessageCount(string mail);
    List<AdminNavbarMessageImagesDto> GetLast3ReceiverMessage(string mail);
}
