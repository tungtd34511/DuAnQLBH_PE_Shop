using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Repositories.Catalog.Units;
using App.Data.Repositories.Promotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Promotions
{
    public class PromotionRepositories : BaseRepositories<Promotion>, IPromotionRepositories
    {
        public PromotionRepositories(QLBH_Context context) : base(context)
        {
        }
    }
}
