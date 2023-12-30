using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete;

public class FeatureService : IFeatureService
{
	private readonly IFeatureDal _featureDal;

	public FeatureService(IFeatureDal featureDal)
	{
		_featureDal = featureDal;
	}

	public void Add(Feature entity)
	{
		_featureDal.Add(entity);
	}

	public List<Feature> GetAll()
	{
		return _featureDal.GetAll();	
	}

	public Feature GetById(int id)
	{
		return _featureDal.GetById(id);
	}

	public void Remove(Feature entity)
	{
		_featureDal.Remove(entity);
	}

	public void Update(Feature entity)
	{
		_featureDal.Update(entity);
	}
}
