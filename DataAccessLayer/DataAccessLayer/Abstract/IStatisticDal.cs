﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract;

public interface IStatisticDal
{
    int GetProjectCount();
    int GetUserCount();
    int GetSkillCount();
    int GetWebMessageCount();
}
