using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Repositories.Catalog.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Catalog.Sizes
{
    public class SizeRepositories : BaseRepositories<Size>, ISizeRepositories
    {
        public SizeRepositories(QLBH_Context context) : base(context)
        {
        }
    }
}
