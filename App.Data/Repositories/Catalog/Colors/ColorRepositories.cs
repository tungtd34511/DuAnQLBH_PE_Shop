using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Colors;
using App.Data.Ultilities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Catalog.Colors
{
    public class ColorRepositories : BaseRepositories<Color>, IColorRepositories
    {
        public ColorRepositories(QLBH_Context context) : base(context)
        {
        }

        public async Task<List<ColorsForCreate>> GetAllForCreate()
        {
            try
            {
                return await Entities.Where(c => c.IsDeleted == false).Select(c => new ColorsForCreate() { Id = c.Id, Name = c.Name }).ToListAsync();
            }
            catch
            {
                return new();
            }
        }
        public async Task<PagedResult<Color>> GetPaging(GetColorPagingRequest request)
        {
            try
            {
    //            Không sắp xếp
    //Theo mã sản phẩm(Tăng)
    //            Theo mã sản phẩm(Giảm)
    //            Theo tên(A-Z)
    //            Theo tên(Z-A)
    //            Theo trạng thái(Hiện - Ẩn)
    //            Theo trạng thái(Ẩn - Hiện)
                var query = Entities.Select(c => c);
                if (!String.IsNullOrEmpty(request.Keyword))
                {
                    query = query.Where(c => c.Id == request.Keyword || c.Name.ToLower().Contains(request.Keyword.ToLower()));
                }
                if (!request.UnHide)
                {
                    query = query.Where(c => c.IsDeleted == false);
                }
                //
                if (!String.IsNullOrEmpty(request.Keyword))
                {
                    query = query.Where(c => c.Name.ToLower().Contains(request.Keyword.ToLower()) || c.Id.ToLower().Contains(request.Keyword.ToLower()));
                }
                if (!request.UnHide)
                {
                    query = query.Where(c => c.IsDeleted == false);
                }
                switch (request.Orderby)
                {
                    case 0:
                        break;
                    case 1:
                        query = query.OrderBy(c => c.Id);
                        break;
                    case 2:
                        query = query.OrderByDescending(c => c.Id);
                        break;
                    case 3:
                        query = query.OrderBy(c => c.Name);
                        break;
                    case 4:
                        query = query.OrderByDescending(c => c.Name);
                        break;
                    case 5:
                        query = query.OrderBy(c => c.IsDeleted);
                        break;
                    case 6:
                        query = query.OrderByDescending(c => c.IsDeleted);
                        break;
                }

                var total = await query.CountAsync();
                var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                    .Take(request.PageSize).ToListAsync();
                //4. Select 

                var pagedResult = new PagedResult<Color>()
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
                return new PagedResult<Color>()
                {
                    Items = new(),
                    PageSize = 20,
                    PageIndex = 1,
                    TotalRecords = 0
                };
            }
        }
        public async Task<string> Validate(string id, string Name)
        {
            var txt = "";
            if (await Entities.AllAsync(c => c.Id == id))
            {
                txt += "Mã màu đã tồn tại!\n";
            }
            if (await Entities.AllAsync(c => c.Name.ToLower() == Name.ToLower()))
            {
                txt += "Tên màu đã tồn tại!\n";
            }
            return txt;
        }
    }
}
