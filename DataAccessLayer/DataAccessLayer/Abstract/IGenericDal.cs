using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract;

public interface IGenericDal<TEntity> where TEntity : class
{
	void Add(TEntity entity);
	void Remove(TEntity entity);
	void Update(TEntity entity);
	List<TEntity> GetAll();
	TEntity GetById(int id);
}
