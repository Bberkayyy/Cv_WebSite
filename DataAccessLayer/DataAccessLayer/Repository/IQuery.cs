﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository;

public interface IQuery<TEntity>
{
    IQueryable<TEntity> Query();
}
