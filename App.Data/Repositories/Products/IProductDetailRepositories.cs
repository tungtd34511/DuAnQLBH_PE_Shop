using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Products
{
    public interface IProductDetailRepositories : IBaseRepositories<ProductDetail>
    {
        Task<bool> ContainsName(string text);
        Task<List<DetailForCretatePromotion>> GetDetailForCreatePromotion();
        Task<string> Validate(string Name);
    }
}
