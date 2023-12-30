using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete;

public class PortfolioService : IPortfolioService
{
	private readonly IPortfolioDal _portfolioDal;

	public PortfolioService(IPortfolioDal portfolioDal)
	{
		_portfolioDal = portfolioDal;
	}

	public void Add(Portfolio entity)
	{
		_portfolioDal.Add(entity);
	}

	public List<Portfolio> GetAll()
	{
		return _portfolioDal.GetAll();
	}

	public Portfolio GetById(int id)
	{
		return _portfolioDal.GetById(id);
	}

	public void Remove(Portfolio entity)
	{
		_portfolioDal.Remove(entity);
	}

	public void Update(Portfolio entity)
	{
		_portfolioDal.Update(entity);
	}
}
