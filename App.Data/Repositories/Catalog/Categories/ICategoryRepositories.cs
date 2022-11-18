using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Categories;

namespace App.Data.Repositories.Catalog.Categories
{
    public interface ICategoryRepositories : IBaseRepositories<Category>
    {
        Task<List<CategoryForCreate>> GetAllForCreate();
    }
}
