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

public class PortfolioService : IPortfolioService
{
    private readonly IPortfolioDal _PortfolioDal;

    public PortfolioService(IPortfolioDal PortfolioDal)
    {
        _PortfolioDal = PortfolioDal;
    }

    public void Add(PortfolioCreateRequestDto PortfolioCreateRequest)
    {
        var value = PortfolioCreateRequestDto.ConverToEntity(PortfolioCreateRequest);
        _PortfolioDal.Add(value);
    }

    public List<PortfolioResponseDto> GetAll()
    {
        var values = _PortfolioDal.GetAll();
        return values.Select(x => PortfolioResponseDto.ConvertToResponse(x)).ToList();

    }

    public PortfolioResponseDto GetById(int id)
    {
        var value = _PortfolioDal.GetById(id);
        return PortfolioResponseDto.ConvertToResponse(value);
    }

    public void Remove(int id)
    {
        var value = _PortfolioDal.GetById(id);
        _PortfolioDal.Remove(value);
    }

    public void Update(PortfolioUpdateRequestDto PortfolioUpdateRequest)
    {
        var value = PortfolioUpdateRequestDto.ConverToEntity(PortfolioUpdateRequest);
        _PortfolioDal.Update(value);
    }
}
