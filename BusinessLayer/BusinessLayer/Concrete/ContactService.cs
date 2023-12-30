using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete;

public class ContactService : IContactService
{
	private readonly IContactDal _contactDal;

	public ContactService(IContactDal contactDal)
	{
		_contactDal = contactDal;
	}

	public void Add(Contact entity)
	{
		_contactDal.Add(entity);
	}

	public List<Contact> GetAll()
	{
		return _contactDal.GetAll();
	}

	public Contact GetById(int id)
	{
		return _contactDal.GetById(id);
	}

	public void Remove(Contact entity)
	{
		_contactDal.Remove(entity);
	}

	public void Update(Contact entity)
	{
		_contactDal.Update(entity);
	}
}
