using DataAccessLayer.Abstract;
using DataAccessLayer.BaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete;

public class StatisticDal : IStatisticDal
{
    private readonly BaseDbContext _context;

    public StatisticDal(BaseDbContext context)
    {
        _context = context;
    }

    public int GetProjectCount()
    {
        return _context.Portfolios.Count();
    }

    public int GetSkillCount()
    {
        return _context.Skills.Count();
    }

    public int GetUserCount()
    {
        return _context.Users.Count();
    }

    public int GetWebMessageCount()
    {
        return _context.Messages.Count();
    }
}
