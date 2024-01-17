using EntityLayer.Concrete;
using EntityLayer.Dtos.RequestDtos;
using EntityLayer.Dtos.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract;

public interface ITestimonialService
{
    void Add(TestimonialCreateRequestDto TestimonialCreateRequest);
    void Remove(int id);
    void Update(TestimonialUpdateRequestDto TestimonialUpdateRequest);
    List<TestimonialResponseDto> GetAll();
    TestimonialResponseDto GetById(int id);

    void ChangeTestimonialShowcaseToFalse(int id);
    void ChangeTestimonialShowcaseToTrue(int id);
}
