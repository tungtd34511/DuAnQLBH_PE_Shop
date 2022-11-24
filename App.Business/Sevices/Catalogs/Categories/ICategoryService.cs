using App.Data.Entities;
using App.Data.Ultilities.Catalog.Categories;
using App.Data.Ultilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Sevices.Catalogs.Categories
{
    public interface ICategoryService
    {
        Task<bool> Add(Category category);
        Task<bool> Edit(Category category);
        Task<bool> ChangeStatus(Category category);
        Task<Category> GetCategoryById(int id);
        Task<PagedResult<Category>> GetPaging(GetPagingCategoryRequest request);
        Task<IEnumerable<Category>> GetAll();
    }
}
