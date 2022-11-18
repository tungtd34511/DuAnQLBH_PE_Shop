
using App.Business.Models.Products;
using App.Data.Ultilities.Catalog.Product;
using App.Data.Ultilities.Common;
using App.Data.Ultilities.PagingModels;
using App.Data.Ultilities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Sevices.Products
{
    public interface IProductServices
    {
        Task<bool> Create(AddProductRequest request, bool dispose);

        Task<bool> Update(UpdateProductRequest request);

        Task<bool> ChangeStatus(ChangeStatusProductRequest request);

        Task<ProductVm> GetById(int Id);
        Task<PagedResult<ProductInPaging>> GetAllPaging(GetPagingProductRequest request);
        Task<string> SaveFile(string path);
        Task<CreateProductView> GetDataForCreate();
        Task<bool> ContainsName(string name);
        Task<DataForProductFilter> GetDataForFilter();
    }
}
