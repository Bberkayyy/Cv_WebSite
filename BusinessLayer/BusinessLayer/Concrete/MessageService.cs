using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete;

public class MessageService : IMessageService
{
	private readonly IMessageDal _messageDal;

	public MessageService(IMessageDal messageDal)
	{
		_messageDal = messageDal;
	}

	public void Add(Message entity)
	{

		_messageDal.Add(entity);
	}

	public List<Message> GetAll()
	{
		return _messageDal.GetAll();
	}

	public Message GetById(int id)
	{
		return _messageDal.GetById(id);
	}

	public void Remove(Message entity)
	{
		_messageDal.Remove(entity);
	}

	public void Update(Message entity)
	{
		_messageDal.Update(entity);
	}
}
