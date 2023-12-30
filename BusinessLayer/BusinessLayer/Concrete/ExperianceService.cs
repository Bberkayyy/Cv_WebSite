using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete;

public class ExperianceService : IExperianceService
{
	private readonly IExperianceDal _expoerianceDal;

	public ExperianceService(IExperianceDal expoerianceDal)
	{
		_expoerianceDal = expoerianceDal;
	}

	public void Add(Experiance entity)
	{
		_expoerianceDal.Add(entity);
	}

	public List<Experiance> GetAll()
	{
		return _expoerianceDal.GetAll();
	}

	public Experiance GetById(int id)
	{
		return _expoerianceDal.GetById(id);
	}

	public void Remove(Experiance entity)
	{
		_expoerianceDal.Remove(entity);
	}

	public void Update(Experiance entity)
	{
		_expoerianceDal.Update(entity);
	}
}
