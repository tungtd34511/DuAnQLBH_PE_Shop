
using App.Data.Entities;
using App.Data.Repositories.Products;
using App.Data.Ultilities.Catalog.ProductVariation;
using App.Data.Ultilities.Common;
using App.Data.Ultilities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Sevices.ProductVariations
{
    public class ProductVariationServices : IProductVariationServices
    {
        private readonly IProductVariationRepositories _repositories;

        public ProductVariationServices(IProductVariationRepositories repositories)
        {
            _repositories = repositories;
        }

        public async Task<bool> ChangeStatus(ChangeStatusProductVariationRequest request)
        {
            var result = await _repositories.ChangeStatus(request.Id,request.IsDeleted);
            return result;
        }

        public async Task<bool> Create(AddProductVariationRequest request)
        {
            return await _repositories.AddOneAsync(new ()
            {
                ColorId = request.ColorId,
                IsDeleted = request.IsDeleted,
                SizeId = request.SizeId,
                Stock = request.Stock,
                ProductId = request.ProductId
            });
        }

        public Task<PagedResult<ProductVariationVm>> GetAllPaging(GetPagingProductVariationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ProductVariationVm> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductVariationVm>> GetByProductId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateStok(UpdateStockProductVariationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
