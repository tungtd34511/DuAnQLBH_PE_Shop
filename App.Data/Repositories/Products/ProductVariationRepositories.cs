using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Products
{
    public class ProductVariationRepositories : BaseRepositories<ProductVariation>, IProductVariationRepositories
    {
        public ProductVariationRepositories(QLBH_Context context) : base(context)
        {
        }
    }
}
