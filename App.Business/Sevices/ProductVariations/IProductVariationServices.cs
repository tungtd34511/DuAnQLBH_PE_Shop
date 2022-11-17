
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
        Task<List<ProductVariationVm>> GetByProductId(int id);
        Task<PagedResult<ProductVariationVm>> GetAllPaging(GetPagingProductVariationRequest request);
        Task<ProductVariationVm> GetById(int id);
        Task<bool> Create(AddProductVariationRequest request);
        Task<bool> UpdateStok(UpdateStockProductVariationRequest request);
        Task<bool> ChangeStatus(ChangeStatusProductVariationRequest request);
    }
}
