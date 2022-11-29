using App.Data.Entities;
using App.Data.Repositories.Catalog.Categories;
using App.Data.Repositories.Products;
using App.Data.Repositories.Promotions;
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
    public class PromotionService : IPromotionService
    {
        private readonly IProductDetailRepositories _productDetailRepositories;
        private readonly ICategoryRepositories _categoryRepositories;
        private readonly IPromotionRepositories _promotionRepositories;
        public PromotionService(IProductDetailRepositories productDetailRepositories, ICategoryRepositories categoryRepositories, IPromotionRepositories promotionRepositories)
        {
            _productDetailRepositories = productDetailRepositories;
            _categoryRepositories = categoryRepositories;
            _promotionRepositories = promotionRepositories;
        }
        public async Task<List<DetailForCretatePromotion>> GetProducts()
        {
            return await _productDetailRepositories.GetDetailForCreatePromotion();
        }
        public async Task<List<CategoryForCreate>> GetCategories()
        {
            return await _categoryRepositories.GetAllForCreate();
        }
        public async Task<bool> Create(Promotion promotion)
        {
            return await _promotionRepositories.AddOneAsync(promotion);
        }
        public async Task<bool> Update(Promotion promotion)
        {
            return await _promotionRepositories.UpdateOneAsync(promotion);
        }
        public async Task<Promotion> GetById(int id)
        {
            return await _promotionRepositories.GetAsync(new object[] { id });
        }
        public async Task<IEnumerable<Promotion>> GetAll()
        {
            return await _promotionRepositories.GetAllAsync();
        }
        public async Task<PagedResult<Promotion>> GetPaging(GetPromotionPagingRequest request)
        {
            return await _promotionRepositories.GetPaging(request);
        }
        public async Task<string> Validation(string Name)
        {
            return await _promotionRepositories.Validation(Name);
        }
    }
}
