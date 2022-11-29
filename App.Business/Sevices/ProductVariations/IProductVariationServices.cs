
using App.Data.Entities;
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
    public interface IProductVariationServices
    {
        Task<bool> Create(ProductVariation request);
        Task<PagedResult<ProductVariationVm>> GetAllPaging(GetPagingProductVariationRequest request);
        Task<ProductVariation> GetById(int id);
        Task<bool> Update(ProductVariation request);
        Task<IEnumerable<Color>> GetAllColor();
        Task<IEnumerable<ProductDetail>> GetAllProductDetail();
        Task<IEnumerable<Size>> GetAllSize();
        Task<bool> Contain(ProductVariation request);
    }
}
