using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Colors;
using App.Data.Ultilities.Catalog.ProductVariation;
using App.Data.Ultilities.Common;
using App.Data.Ultilities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Products
{
    public interface IProductVariationRepositories : IBaseRepositories<ProductVariation>
    {
        Task<bool> ChangeStatus(int pvId, bool status);
        Task<PagedResult<ProductVariationVm>> GetPaging(GetPagingProductVariationRequest request);
        Task<List<ProductVariation>> GetByProductId(int pId);
        Task<List<ProductVariationVm>> GetVMByProductId(int pId);
        Task<bool> Contain(ProductVariation request);
        Task<ProductVariationVm> GetByQR(int id);

	}
}
