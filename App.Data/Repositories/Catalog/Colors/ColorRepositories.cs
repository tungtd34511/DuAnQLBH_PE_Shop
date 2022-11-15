using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Catalog.Colors
{
    public class ColorRepositories : BaseRepositories<Color>, IBaseRepositories<Color>
    {
        public ColorRepositories(QLBH_Context context) : base(context)
        {
        }
    }
}
