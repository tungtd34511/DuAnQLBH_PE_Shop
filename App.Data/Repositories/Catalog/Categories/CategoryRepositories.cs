using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Repositories.Catalog.Categories;
using App.Data.Ultilities.Catalog.Categories;
using App.Data.Ultilities.Catalog.Manufacturers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Catalog.Categories
{
    public class CategoryRepositories : BaseRepositories<Category>, ICategoryRepositories
    {
        public CategoryRepositories(QLBH_Context context) : base(context)
        {
        }

        public async Task<List<CategoryForCreate>> GetAllForCreate()
        {
            return await (Entities.Where(c=>c.IsDeleted==false).Select(c => new CategoryForCreate() { Id = c.Id, Name = c.Name }).ToListAsync());
        }
    }
}
