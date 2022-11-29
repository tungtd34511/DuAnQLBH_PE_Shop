using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Repositories.Catalog.Units;
using App.Data.Repositories.Promotions;
using App.Data.Ultilities.Catalog.Promotion;
using App.Data.Ultilities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Promotions
{
    public class PromotionRepositories : BaseRepositories<Promotion>, IPromotionRepositories
    {
        public PromotionRepositories(QLBH_Context context) : base(context)
        {
        }
        public async Task<PagedResult<Promotion>> GetPaging(GetPromotionPagingRequest request)
        {
            var query = Entities.Select(c=>c);
            if(!String.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(c=>c.Id.ToString()==request.Keyword||c.Title.ToLower().Contains(request.Keyword.ToLower()));
            }
            if (!request.Unhide)
            {
                query= query.Where(c => c.Status == Ultilities.Enums.PromotionStatus.Active);
            }
            var totalrecord = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(c => c).ToListAsync();
            var result = new PagedResult<Promotion>()
            {
                TotalRecords = totalrecord,
                PageSize = request.PageSize,
                Items = data,
                PageIndex = request.PageIndex
            };
            return result;
        }
        public async Task<string> Validation(string Name)
        {
            if(await Entities.AnyAsync(c=>c.Name.ToLower()==Name.ToLower()))
            {
                return "Tên khuyến mãi đã tồn tại !\n";
            }
            return "";
        }
    }
}
