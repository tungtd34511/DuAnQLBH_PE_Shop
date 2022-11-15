using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Carts
{
    public class ProductInCartRepositories : BaseRepositories<ProductInCart>, IProductInCartRepositories
    {
        public ProductInCartRepositories(QLBH_Context context) : base(context)
        {
        }
    }
}
