using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract;

public interface IGenericDal<TEntity> where TEntity : class
{
    void Add(TEntity entity);
    void Remove(TEntity entity);
    void Update(TEntity entity);
    List<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
    TEntity GetById(int id);
}
