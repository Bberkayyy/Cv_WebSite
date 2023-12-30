using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete;

public class SocialMediaService : ISocialMediaService
{
	private readonly ISocialMediaDal _socialMediaDal;

	public SocialMediaService(ISocialMediaDal socialMediaDal)
	{
		_socialMediaDal = socialMediaDal;
	}

	public void Add(SocialMedia entity)
	{
		_socialMediaDal.Add(entity);
	}

	public List<SocialMedia> GetAll()
	{
		return _socialMediaDal.GetAll();
	}

	public SocialMedia GetById(int id)
	{
		return _socialMediaDal.GetById(id);
	}

	public void Remove(SocialMedia entity)
	{
		_socialMediaDal.Remove(entity);
	}

	public void Update(SocialMedia entity)
	{
		_socialMediaDal.Update(entity);
	}
}
