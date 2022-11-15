using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Repositories.Catalog.Categories;
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
    }
}
