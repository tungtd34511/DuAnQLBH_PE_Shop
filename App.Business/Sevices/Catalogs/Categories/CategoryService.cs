using App.Data.Entities;
using App.Data.Repositories.Catalog.Categories;
using App.Data.Ultilities.Catalog.Categories;
using App.Data.Ultilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Sevices.Catalogs.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepositories _categoryRepositories;

        public CategoryService(ICategoryRepositories categoryRepositories)
        {
            _categoryRepositories = categoryRepositories;
        }

        public async Task<bool> Add(Category category)
        {
            return await _categoryRepositories.AddOneAsync(category);
        }

        public async Task<bool> ChangeStatus(Category category)
        {
            return await _categoryRepositories.UpdateOneAsync(category);
        }

        public async Task<bool> Edit(Category category)
        {
            return await _categoryRepositories.UpdateOneAsync(category);
        }
        public async Task<Category> GetCategoryById(int id)
        {
            return await _categoryRepositories.GetAsync(new object[] { id });
        }

        public async Task<PagedResult<Category>> GetPaging(GetPagingCategoryRequest request)
        {
            return await _categoryRepositories.GetPaging(request);
        }
        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _categoryRepositories.GetAllAsync();
        }
    }
}
