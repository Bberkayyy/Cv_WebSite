using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.RequestDtos;

public record FeatureUpdateRequestDto(int Id,
                                      string Header,
                                      string Name,
                                      string Title)
{
    public static Feature ConverToEntity(FeatureUpdateRequestDto request)
    {
        return new Feature
        {
            Id = request.Id,
            Header = request.Header,
            Name = request.Name,
            Title = request.Title,
        };
    }
}
