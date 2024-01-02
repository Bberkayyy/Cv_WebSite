using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.RequestDtos;

public record PortfolioUpdateRequestDto(int Id,
                                        string Platform,
                                        string ProjectName,
                                        string ProjectUrl,
                                        string ProjectImageUrl,
                                        string ProjectBigImageUrl)
{
    public static Portfolio ConverToEntity(PortfolioUpdateRequestDto request)
    {
        return new Portfolio
        {
            Id = request.Id,
            Platform = request.Platform,
            ProjectName = request.ProjectName,
            ProjectUrl = request.ProjectUrl,
            ProjectImageUrl = request.ProjectImageUrl,
            ProjectBigImageUrl = request.ProjectBigImageUrl
        };
    }
}
