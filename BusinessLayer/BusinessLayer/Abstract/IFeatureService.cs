using EntityLayer.Concrete;
using EntityLayer.Dtos.RequestDtos;
using EntityLayer.Dtos.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract;

public interface IFeatureService
{
    void Add(FeatureCreateRequestDto FeatureCreateRequest);
    void Remove(int id);
    void Update(FeatureUpdateRequestDto FeatureUpdateRequest);
    List<FeatureResponseDto> GetAll();
    FeatureResponseDto GetById(int id);
}
