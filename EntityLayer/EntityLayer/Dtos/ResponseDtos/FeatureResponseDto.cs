using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.ResponseDtos;

public record FeatureResponseDto(int Id,
                                  string Header,
                                  string Name,
                                  string Title)
{
    public static FeatureResponseDto ConvertToResponse(Feature Feature)
    {
        return new FeatureResponseDto(
            Id: Feature.Id,
            Header: Feature.Header,
            Name: Feature.Name,
            Title: Feature.Title);
    }
}
