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

public class VisitorMessageService : IVisitorMessageService
{
    private readonly IVisitorMessageDal _visitorMessageDal;

    public VisitorMessageService(IVisitorMessageDal visitorMessageDal)
    {
        _visitorMessageDal = visitorMessageDal;
    }

    public void Add(VisitorMessageCreateRequestDto VisitorMessageCreateRequest)
    {
        var value = VisitorMessageCreateRequestDto.ConvertToEntity(VisitorMessageCreateRequest);
        _visitorMessageDal.Add(value);
    }

    public List<VisitorMessageResponseDto> GetAll()
    {
        var values = _visitorMessageDal.GetAll();
        return values.Select(x => VisitorMessageResponseDto.ConvertToResponse(x)).ToList();
    }

    public List<VisitorMessageResponseDto> GetReceiverMessages(string mail)
    {
        var values = _visitorMessageDal.GetAll(x => x.ReceiverMail == mail);
        return values.Select(x => VisitorMessageResponseDto.ConvertToResponse(x)).ToList();
    }

    public VisitorMessageResponseDto GetById(int id)
    {
        var value = _visitorMessageDal.GetById(id);
        return VisitorMessageResponseDto.ConvertToResponse(value);
    }

    public void Remove(int id)
    {
        var value = _visitorMessageDal.GetById(id);
        _visitorMessageDal.Remove(value);
    }

    public void Update(VisitorMessageUpdateRequestDto VisitorMessageUpdateRequest)
    {
        var value = VisitorMessageUpdateRequestDto.ConvertToEntity(VisitorMessageUpdateRequest);
        _visitorMessageDal.Update(value);
    }

    public List<VisitorMessageResponseDto> GetSenderMessages(string mail)
    {
        var values = _visitorMessageDal.GetAll(x => x.SenderMail == mail);
        return values.Select(x => VisitorMessageResponseDto.ConvertToResponse(x)).ToList();
    }
}
