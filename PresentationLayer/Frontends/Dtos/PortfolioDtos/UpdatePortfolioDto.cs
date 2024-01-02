using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.PortfolioDtos;

public class UpdatePortfolioDto
{
    public int Id { get; set; }
    public string Platform { get; set; }
    public string ProjectName { get; set; }
    public string ProjectUrl { get; set; }
    public string ProjectImageUrl { get; set; }
    public string ProjectBigImageUrl { get; set; }
}
