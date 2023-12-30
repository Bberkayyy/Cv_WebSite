using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete;

public class AboutService : IAboutService
{
	private readonly IAboutDal _aboutDal;

	public AboutService(IAboutDal aboutDal)
	{
		_aboutDal = aboutDal;
	}

	public void Add(About entity)
	{
		_aboutDal.Add(entity);
	}

	public List<About> GetAll()
	{
		return _aboutDal.GetAll();
	}

	public About GetById(int id)
	{
		return _aboutDal.GetById(id);
	}

	public void Remove(About entity)
	{
		_aboutDal.Remove(entity);
	}

	public void Update(About entity)
	{
		_aboutDal.Update(entity);
	}
}
