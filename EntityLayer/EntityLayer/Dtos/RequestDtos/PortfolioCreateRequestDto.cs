﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.RequestDtos;

public record PortfolioCreateRequestDto(string ProjectName,
                                        string ProjectUrl,
                                        string ProjectImageUrl,
                                        string ProjectBigImageUrl)
{
    public static Portfolio ConverToEntity(PortfolioCreateRequestDto request)
    {
        return new Portfolio
        {
            ProjectName = request.ProjectName,
            ProjectUrl = request.ProjectUrl,
            ProjectImageUrl = request.ProjectImageUrl,
            ProjectBigImageUrl = request.ProjectBigImageUrl,
        };
    }
}
