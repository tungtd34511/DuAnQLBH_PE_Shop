using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Units;
using App.Data.Ultilities.Common;
using App.Data.Ultilities.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace App.Data.Repositories.Catalog.Units
{
    public class UnitRepositories : BaseRepositories<Unit>, IUnitRepositories
    {
        public UnitRepositories(QLBH_Context context) : base(context)
        {
        }

        public async Task<bool> CheckName(string name)
        {
            return await Entities.AllAsync(u => u.Name.ToLower() == name.ToLower());
        }

        public async Task<List<UnitForCreate>> GetAllForCreate()
        {
            return await (Entities.Where(c => c.IsDeleted == false).Select(c => new UnitForCreate() { Id = c.Id, Name = c.Name }).ToListAsync());
        }
        public async Task<PagedResult<Unit>> GetPaging(GetPagingUnitRequest request)
        {
            var query = Entities.Where(c=>c.IsDeleted== false);
            var total = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize).ToListAsync();
            //4. Select 

            var pagedResult = new PagedResult<Unit>()
            {
                TotalRecords = total,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }
    }
}
