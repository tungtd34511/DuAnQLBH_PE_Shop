﻿using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Repositories.Catalog.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Catalog.Units
{
    public class UnitRepositories : BaseRepositories<Unit>, IUnitRepositories
    {
        public UnitRepositories(QLBH_Context context) : base(context)
        {
        }
    }
}
