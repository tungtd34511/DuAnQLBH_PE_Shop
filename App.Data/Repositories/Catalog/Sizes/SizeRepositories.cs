using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Repositories.Catalog.Units;
using App.Data.Ultilities.Catalog.Colors;
using App.Data.Ultilities.Catalog.Sizes;
using App.Data.Ultilities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Catalog.Sizes
{
    public class SizeRepositories : BaseRepositories<Size>, ISizeRepositories
    {
        public SizeRepositories(QLBH_Context context) : base(context)
        {
        }
        public async Task<List<SizesForCreate>> GetAllForCreate()
        {
            return await Entities.Where(c => c.IsDeleted == false).Select(c => new SizesForCreate() { Id = c.Id, Name = c.Name }).ToListAsync();
        }
        public async Task<PagedResult<Size>> GetPaging(GetSizePagingRequest request)
        {
            var query = Entities.Select(c => c);
            if (!String.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(c => c.Id.ToString() == request.Keyword || c.Name.ToLower().Contains(request.Keyword.ToLower()));
            }
            if (!request.UnHide)
            {
                query = query.Where(c => c.IsDeleted == false);
            }
            var total = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize).ToListAsync();
            //4. Select 

            var pagedResult = new PagedResult<Size>()
            {
                TotalRecords = total,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<string> Validate(string id, string name)
        {
            var eror = "";
            if (Entities.Any(c => c.Id == id))
            {
                eror += "Mã kích cỡ đã tồn tại";
            }
            if (Entities.Any(c => c.Name.ToLower() == name))
            {
                eror += "Tên kích cỡ đã tồn tại";
            }
            return eror;
        }
    }
}
