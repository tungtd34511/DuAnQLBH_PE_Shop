using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Repositories.Catalog.Categories;
using App.Data.Ultilities.Catalog.Categories;
using App.Data.Ultilities.Catalog.Manufacturers;
using App.Data.Ultilities.Common;
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
            return await (Entities.Where(c => c.IsDeleted == false).Select(c => new CategoryForCreate() { Id = c.Id, Name = c.Name }).ToListAsync());
        }
        public async Task<PagedResult<Category>> GetPaging(GetPagingCategoryRequest request)
        {
            try
            {
                //            Không sắp xếp
                //Theo mã(Tăng)
                //Theo mã(Giảm)
                //Theo tên(A-Z)
                //Theo tên(Z-A)
                //Theo danh mục cha(A-Z)
                //Theo danh mục cha(Z-A)
                //Theo trạng thái(Inactive - Active)
                //Theo trạng thái(Active - Inactive)
                var query = from c in Entities
                            join cp in Entities on c.ParentId equals cp.Id into cs
                            from cpi in cs.DefaultIfEmpty()
                            select new { c, cpi };
                if (!String.IsNullOrEmpty(request.Keyword))
                {
                    query = query.Where(c => c.c.Name.ToLower().Contains(request.Keyword.ToLower()) || c.cpi.Name.ToLower().Contains(request.Keyword.ToLower()));
                }
                if (!request.Unhide)
                {
                    query = query.Where(c => c.c.IsDeleted == false);
                }
                switch (request.Orderby)
                {
                    case 0:
                        break;
                    case 1:
                        query = query.OrderBy(c => c.c.Id);
                        break;
                    case 2:
                        query = query.OrderByDescending(c => c.c.Id);
                        break;
                    case 3:
                        query = query.OrderBy(c => c.c.Name);
                        break;
                    case 4:
                        query = query.OrderByDescending(c => c.c.Name);
                        break;
                    case 5:
                        query = query.OrderBy(c => c.cpi.Id);
                        break;
                    case 6:
                        query = query.OrderByDescending(c => c.cpi.Id);
                        break;
                    case 7:
                        query = query.OrderBy(c => c.c.IsDeleted);
                        break;
                    case 8:
                        query = query.OrderByDescending(c => c.c.IsDeleted);
                        break;

                }
                var total = await query.CountAsync();
                var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                    .Take(request.PageSize).
                    Select(c => new Category()
                    {
                        Id = c.c.Id,
                        IsDeleted = c.c.IsDeleted,
                        Description = c.c.Description,
                        Name = c.c.Name,
                        ParentId = c.c.ParentId,
                        Parent = c.cpi
                    }).ToListAsync();
                //4. Select 

                var pagedResult = new PagedResult<Category>()
                {
                    TotalRecords = total,
                    PageSize = request.PageSize,
                    PageIndex = request.PageIndex,
                    Items = data
                };

                return pagedResult;
            }
            catch
            {
                return new PagedResult<Category>() { Items = new List<Category>(), PageSize = 20, PageIndex = 1, TotalRecords = 0 };
            }
        }

        public async Task<string> Validate(string name)
        {
            var text = "";
            if (await Entities.AnyAsync(c => c.Name.ToLower().Contains(name.ToLower())))
            {
                text += "Tên danh mục đã tồn tại!";
            }
            return text;
        }
    }
}
