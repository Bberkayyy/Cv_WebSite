using DataAccessLayer.Abstract;
using DataAccessLayer.BaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository;

public class GenericRepository<TContext, TEntity> : IGenericDal<TEntity>, IQuery<TEntity>
    where TEntity : class
    where TContext : DbContext
{
    protected TContext Context { get; set; }

    public GenericRepository(TContext context)
    {
        Context = context;
    }

    public void Add(TEntity entity)
    {
        Context.Set<TEntity>().Add(entity);
        Context.SaveChanges();
    }

    public void Remove(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
        Context.SaveChanges();
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        IQueryable<TEntity> queryable = Query();
        if (predicate is not null)
            queryable = queryable.Where(predicate);
        if (include is not null)
            queryable = include(queryable);
        return queryable.ToList();
    }

    public TEntity GetById(int id)
    {
        return Context.Set<TEntity>().Find(id);
    }

    public void Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
        Context.SaveChanges();
    }
    public IQueryable<TEntity> Query() => Context.Set<TEntity>();
}
