using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Products;
using App.Data.Ultilities.Common;
using App.Data.Ultilities.PagingModels;
using App.Data.Ultilities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Products
{
    public interface IProductRepositories : IBaseRepositories<Product>
    {
        Task<PagedResult<ProductInPaging>> GetAllPaging1(GetPagingProductRequest request);
        Task<ProductVm> GetById(int prodcutId);
        Task<PagedResult<ProductInShoppingVm>> GetPagingForShopping(GetPagingShoppingRequest request);
    }
}
