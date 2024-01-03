using DataAccessLayer.Abstract;
using DataAccessLayer.BaseContext;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete;

public class UserDal : GenericRepository<BaseDbContext, User>, IUserDal
{
    public UserDal(BaseDbContext context) : base(context)
    {

    }
}
