using DataAccessLayer.Abstract;
using DataAccessLayer.BaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository;

public class GenericRepository<TContext,TEntity> : IGenericDal<TEntity> 
	where TEntity : class 
	where TContext : DbContext
{
    public TContext Context { get; set; }

	public GenericRepository(TContext context)
	{
		Context = context;
	}

	public void Add(TEntity entity)
	{
		Context.Add(entity);
		Context.SaveChanges();
	}

	public void Remove(TEntity entity)
	{
		Context.Remove(entity);
		Context.SaveChanges();
	}

	public List<TEntity> GetAll()
	{
		return Context.Set<TEntity>().ToList();
	}

	public TEntity GetById(int id)
	{
		return Context.Set<TEntity>().Find(id);
	}

	public void Update(TEntity entity)
	{
		Context.Update(entity);
		Context.SaveChanges();
	}
}
