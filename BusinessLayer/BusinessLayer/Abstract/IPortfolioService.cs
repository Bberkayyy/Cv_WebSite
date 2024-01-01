using EntityLayer.Concrete;
using EntityLayer.Dtos.RequestDtos;
using EntityLayer.Dtos.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract;

public interface IPortfolioService
{
    void Add(PortfolioCreateRequestDto PortfolioCreateRequest);
    void Remove(int id);
    void Update(PortfolioUpdateRequestDto PortfolioUpdateRequest);
    List<PortfolioResponseDto> GetAll();
    PortfolioResponseDto GetById(int id);
}
