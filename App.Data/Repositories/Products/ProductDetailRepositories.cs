using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Products;
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
        public async Task<List<DetailForCretatePromotion>> GetDetailForCreatePromotion()
        {
            return await Entities.Select(c=>new DetailForCretatePromotion() { Id=c.ProductId, Name=c.Name }).ToListAsync();
        }
        public async Task<string> Validate(string Name)
        {
            if(await Entities.AnyAsync(c => c.Name.ToLower() == Name.ToLower()))
            {
                return "Tên sản phẩm đã tồn tại";
            }
            return "";
        }
    }
}
