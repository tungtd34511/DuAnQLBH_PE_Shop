using App.Data.Entities;
using App.Data.Ultilities.Catalog.Categories;
using App.Data.Ultilities.Catalog.Products;
using App.Data.Ultilities.Catalog.Promotion;
using App.Data.Ultilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Sevices.Promotions
{
    public interface IPromotionService
    {
        Task<List<DetailForCretatePromotion>> GetProducts();
        Task<List<CategoryForCreate>> GetCategories();
        Task<bool> Create(Promotion promotion);
        Task<bool> Update(Promotion promotion);
        Task<Promotion> GetById(int id);
        Task<IEnumerable<Promotion>> GetAll();
        Task<PagedResult<Promotion>> GetPaging(GetPromotionPagingRequest request);
        Task<string> Validation(string Name);
    }
}
