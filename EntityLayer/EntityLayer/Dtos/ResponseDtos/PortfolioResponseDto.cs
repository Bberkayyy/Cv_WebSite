using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.ResponseDtos;

public record PortfolioResponseDto(int Id,
                                    string ProjectName,
                                    string ProjectImageUrl,
                                    string ProjectUrl,
                                    string ProjectBigImageUrl)
{
    public static PortfolioResponseDto ConvertToResponse(Portfolio Portfolio)
    {
        return new PortfolioResponseDto(
            Id: Portfolio.Id,
            ProjectName: Portfolio.ProjectName,
            ProjectUrl: Portfolio.ProjectUrl,
            ProjectImageUrl: Portfolio.ProjectImageUrl,
            ProjectBigImageUrl: Portfolio.ProjectBigImageUrl
            );
    }
}
