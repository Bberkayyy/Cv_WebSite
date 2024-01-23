using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete;

public class StatisticService : IStatisticService
{
    private readonly IStatisticDal _statisticDal;

    public StatisticService(IStatisticDal statisticsDal)
    {
        _statisticDal = statisticsDal;
    }

    public int GetProjectCount()
    {
        return _statisticDal.GetProjectCount();
    }

    public int GetSkillCount()
    {
        return _statisticDal.GetSkillCount();
    }

    public int GetUserCount()
    {
        return _statisticDal.GetUserCount();
    }

    public int GetWebMessageCount()
    {
        return _statisticDal.GetWebMessageCount();
    }
}
