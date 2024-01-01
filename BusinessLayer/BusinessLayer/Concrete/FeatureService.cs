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

public class FeatureService : IFeatureService
{
    private readonly IFeatureDal _FeatureDal;

    public FeatureService(IFeatureDal FeatureDal)
    {
        _FeatureDal = FeatureDal;
    }

    public void Add(FeatureCreateRequestDto FeatureCreateRequest)
    {
        var value = FeatureCreateRequestDto.ConverToEntity(FeatureCreateRequest);
        _FeatureDal.Add(value);
    }

    public List<FeatureResponseDto> GetAll()
    {
        var values = _FeatureDal.GetAll();
        return values.Select(x => FeatureResponseDto.ConvertToResponse(x)).ToList();

    }

    public FeatureResponseDto GetById(int id)
    {
        var value = _FeatureDal.GetById(id);
        return FeatureResponseDto.ConvertToResponse(value);
    }

    public void Remove(int id)
    {
        var value = _FeatureDal.GetById(id);
        _FeatureDal.Remove(value);
    }

    public void Update(FeatureUpdateRequestDto FeatureUpdateRequest)
    {
        var value = FeatureUpdateRequestDto.ConverToEntity(FeatureUpdateRequest);
        _FeatureDal.Update(value);
    }
}
