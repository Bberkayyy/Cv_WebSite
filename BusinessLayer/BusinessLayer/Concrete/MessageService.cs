﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Dtos.RequestDtos;
using EntityLayer.Dtos.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete;

public class MessageService : IMessageService
{
    private readonly IMessageDal _MessageDal;

    public MessageService(IMessageDal MessageDal)
    {
        _MessageDal = MessageDal;
    }

    public void Add(MessageCreateRequestDto MessageCreateRequest)
    {
        var value = MessageCreateRequestDto.ConverToEntity(MessageCreateRequest);
        _MessageDal.Add(value);
    }

    public List<MessageResponseDto> GetAll()
    {
        var values = _MessageDal.GetAll();
        return values.Select(x => MessageResponseDto.ConvertToResponse(x)).ToList();

    }

    public MessageResponseDto GetById(int id)
    {
        var value = _MessageDal.GetById(id);
        return MessageResponseDto.ConvertToResponse(value);
    }

    public void Remove(int id)
    {
        var value = _MessageDal.GetById(id);
        _MessageDal.Remove(value);
    }

    public void Update(MessageUpdateRequestDto MessageUpdateRequest)
    {
        var value = MessageUpdateRequestDto.ConverToEntity(MessageUpdateRequest);
        _MessageDal.Update(value);
    }
}
