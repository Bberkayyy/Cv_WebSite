
using Microsoft.AspNetCore.Http;

namespace Dtos.PortfolioDtos;

public class CreatePortfolioDto
{
    public string ProjectName { get; set; }
    public string ProjectUrl { get; set; }
    public string ProjectImageUrl { get; set; }
    public string ProjectBigImageUrl { get; set; }
    public IFormFile Picture { get; set; }
}
