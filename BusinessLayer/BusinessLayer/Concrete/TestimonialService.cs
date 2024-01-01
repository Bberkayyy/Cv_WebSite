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

public class TestimonialService : ITestimonialService
{
    private readonly ITestimonialDal _TestimonialDal;

    public TestimonialService(ITestimonialDal TestimonialDal)
    {
        _TestimonialDal = TestimonialDal;
    }

    public void Add(TestimonialCreateRequestDto TestimonialCreateRequest)
    {
        var value = TestimonialCreateRequestDto.ConverToEntity(TestimonialCreateRequest);
        _TestimonialDal.Add(value);
    }

    public List<TestimonialResponseDto> GetAll()
    {
        var values = _TestimonialDal.GetAll();
        return values.Select(x => TestimonialResponseDto.ConvertToResponse(x)).ToList();

    }

    public TestimonialResponseDto GetById(int id)
    {
        var value = _TestimonialDal.GetById(id);
        return TestimonialResponseDto.ConvertToResponse(value);
    }

    public void Remove(int id)
    {
        var value = _TestimonialDal.GetById(id);
        _TestimonialDal.Remove(value);
    }

    public void Update(TestimonialUpdateRequestDto TestimonialUpdateRequest)
    {
        var value = TestimonialUpdateRequestDto.ConverToEntity(TestimonialUpdateRequest);
        _TestimonialDal.Update(value);
    }
}
