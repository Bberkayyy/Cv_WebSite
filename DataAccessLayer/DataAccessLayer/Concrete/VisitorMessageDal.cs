using DataAccessLayer.Abstract;
using DataAccessLayer.BaseContext;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete;

public class VisitorMessageDal : GenericRepository<BaseDbContext, VisitorMessage>, IVisitorMessageDal
{
    public VisitorMessageDal(BaseDbContext context) : base(context)
    {
    }
}
