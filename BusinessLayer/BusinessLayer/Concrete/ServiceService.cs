using BusinessLayer.Abstract;
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

public class ServiceService : IServiceService
{
    private readonly IServiceDal _ServiceDal;

    public ServiceService(IServiceDal ServiceDal)
    {
        _ServiceDal = ServiceDal;
    }

    public void Add(ServiceCreateRequestDto ServiceCreateRequest)
    {
        var value = ServiceCreateRequestDto.ConverToEntity(ServiceCreateRequest);
        _ServiceDal.Add(value);
    }

    public List<ServiceResponseDto> GetAll()
    {
        var values = _ServiceDal.GetAll();
        return values.Select(x => ServiceResponseDto.ConvertToResponse(x)).ToList();

    }

    public ServiceResponseDto GetById(int id)
    {
        var value = _ServiceDal.GetById(id);
        return ServiceResponseDto.ConvertToResponse(value);
    }

    public void Remove(int id)
    {
        var value = _ServiceDal.GetById(id);
        _ServiceDal.Remove(value);
    }

    public void Update(ServiceUpdateRequestDto ServiceUpdateRequest)
    {
        var value = ServiceUpdateRequestDto.ConverToEntity(ServiceUpdateRequest);
        _ServiceDal.Update(value);
    }
}
