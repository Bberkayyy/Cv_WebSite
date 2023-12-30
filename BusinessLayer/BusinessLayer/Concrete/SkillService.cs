using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete;

public class SkillService : ISkillService
{
	private readonly ISkillDal _skillDal;

	public SkillService(ISkillDal skillDal)
	{
		_skillDal = skillDal;
	}

	public void Add(Skill entity)
	{
		_skillDal.Add(entity);
	}

	public List<Skill> GetAll()
	{
		return _skillDal.GetAll();
	}

	public Skill GetById(int id)
	{
		return _skillDal.GetById(id);
	}

	public void Remove(Skill entity)
	{
		_skillDal.Remove(entity);
	}

	public void Update(Skill entity)
	{
		_skillDal.Update(entity);
	}
}
