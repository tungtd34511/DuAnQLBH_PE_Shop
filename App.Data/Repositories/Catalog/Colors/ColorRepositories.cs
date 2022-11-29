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
            return await Entities.Where(c => c.IsDeleted == false).Select(c => new ColorsForCreate() { Id = c.Id, Name = c.Name }).ToListAsync();
        }
        public async Task<PagedResult<Color>> GetPaging(GetColorPagingRequest request)
        {
            var query = Entities.Select(c => c);
            if (!String.IsNullOrEmpty(request.Keyword)) { 
                query = query.Where(c => c.Id == request.Keyword || c.Name.ToLower().Contains(request.Keyword.ToLower()));
            }
            if (!request.UnHide)
            {
                query = query.Where(c=>c.IsDeleted== false);
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
        public async Task<string> Validate(string id,string Name)
        {
            var txt = "";
            if(await Entities.AllAsync(c => c.Id == id))
            {
                txt += "Mã màu đã tồn tại!\n";
            }
            if(await Entities.AllAsync(c => c.Name.ToLower() == Name.ToLower()))
            {
                txt += "Tên màu đã tồn tại!\n";
            }
            return txt;
        }
    }
}
