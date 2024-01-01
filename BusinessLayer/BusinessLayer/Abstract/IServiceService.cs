using EntityLayer.Concrete;
using EntityLayer.Dtos.RequestDtos;
using EntityLayer.Dtos.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract;

public interface IServiceService
{
    void Add(ServiceCreateRequestDto ServiceCreateRequest);
    void Remove(int id);
    void Update(ServiceUpdateRequestDto ServiceUpdateRequest);
    List<ServiceResponseDto> GetAll();
    ServiceResponseDto GetById(int id);
}
