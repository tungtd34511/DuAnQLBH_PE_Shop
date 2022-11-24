using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Categories;
using App.Data.Ultilities.Common;

namespace App.Data.Repositories.Catalog.Categories
{
    public interface ICategoryRepositories : IBaseRepositories<Category>
    {
        Task<List<CategoryForCreate>> GetAllForCreate();
        Task<PagedResult<Category>> GetPaging(GetPagingCategoryRequest request);
    }
}
