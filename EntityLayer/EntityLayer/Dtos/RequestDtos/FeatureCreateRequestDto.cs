using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.RequestDtos;

public record FeatureCreateRequestDto(string Header,
                                      string Name,
                                      string Title)
{
    public static Feature ConverToEntity(FeatureCreateRequestDto request)
    {
        return new Feature
        {
            Header = request.Header,
            Name = request.Name,
            Title = request.Title,
        };
    }
}
