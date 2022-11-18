using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Products
{
    public class ProductDetailRepositories : BaseRepositories<ProductDetail>, IProductDetailRepositories
    {
        public ProductDetailRepositories(QLBH_Context context) : base(context)
        {
        }

        public async Task<bool> ContainsName(string text)
        {
            var text1 = text.ToLower();
            return await Entities.AnyAsync(e => e.Name.ToLower() == text1);
        }
    }
}
