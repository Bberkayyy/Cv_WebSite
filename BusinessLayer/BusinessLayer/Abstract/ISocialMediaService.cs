using EntityLayer.Concrete;
using EntityLayer.Dtos.RequestDtos;
using EntityLayer.Dtos.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract;

public interface ISocialMediaService
{
    void Add(SocialMediaCreateRequestDto SocialMediaCreateRequest);
    void Remove(int id);
    void Update(SocialMediaUpdateRequestDto SocialMediaUpdateRequest);
    List<SocialMediaResponseDto> GetAll();
    SocialMediaResponseDto GetById(int id);
}
