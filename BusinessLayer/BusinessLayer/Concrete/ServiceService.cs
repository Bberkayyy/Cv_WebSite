using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete;

public class ServiceService : IServiceService
{
	private readonly IServiceDal _serviceDal;

	public ServiceService(IServiceDal serviceDal)
	{
		_serviceDal = serviceDal;
	}

	public void Add(Service entity)
	{
		_serviceDal.Add(entity);
	}

	public List<Service> GetAll()
	{
		return _serviceDal.GetAll();
	}

	public Service GetById(int id)
	{
		return _serviceDal.GetById(id);
	}

	public void Remove(Service entity)
	{
		_serviceDal.Remove(entity);
	}

	public void Update(Service entity)
	{
		_serviceDal.Update(entity);
	}
}
