
using App.Data.Entities;
using App.Data.Repositories.Catalog.Colors;
using App.Data.Repositories.Catalog.Sizes;
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
        private readonly IColorRepositories _colorRepositories;
        private readonly ISizeRepositories _sizeRepositories;
        private readonly IProductDetailRepositories _productDetailRepositories;

        public ProductVariationServices(IProductVariationRepositories repositories, IColorRepositories colorRepositories, ISizeRepositories sizeRepositories, IProductDetailRepositories productDetailRepositories)
        {
            _repositories = repositories;
            _colorRepositories = colorRepositories;
            _sizeRepositories = sizeRepositories;
            _productDetailRepositories = productDetailRepositories;
        }


        public async Task<bool> Create(ProductVariation request)
        {
            return await _repositories.AddOneAsync(request);
        }

        public async Task<PagedResult<ProductVariationVm>> GetAllPaging(GetPagingProductVariationRequest request)
        {
            return await _repositories.GetPaging(request);
        }

        public async Task<ProductVariation> GetById(int id)
        {
            return await _repositories.GetAsync(new object[] {id});
        }

        public async Task<bool> Update(ProductVariation request)
        {
            return await _repositories.UpdateOneAsync(request);
        }
        public async Task<IEnumerable<Color>> GetAllColor()
        {
            return await _colorRepositories.GetAllAsync();
        }
        public async Task<IEnumerable<ProductDetail>> GetAllProductDetail()
        {
            return await _productDetailRepositories.GetAllAsync();
        }
        public async Task<IEnumerable<Size>> GetAllSize()
        {
            return await _sizeRepositories.GetAllAsync();
        }

        public Task<bool> Contain(ProductVariation request)
        {
            return _repositories.Contain(request);
        }
    }
}
