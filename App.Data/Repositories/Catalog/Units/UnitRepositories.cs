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
            try
            {
                var query = Entities.Select(c=>c);
                if (!String.IsNullOrEmpty(request.Keyword))
                {
                    query = query.Where(c => c.Id.ToString() == request.Keyword || c.Name.ToLower().Contains(request.Keyword.ToLower()));
                }
                if (!request.UnHide)
                {
                    query = query.Where(c => c.IsDeleted == false);
                }
                //
                if (!String.IsNullOrEmpty(request.Keyword))
                {
                    query = query.Where(c => c.Name.ToLower().Contains(request.Keyword.ToLower()) || c.Id.ToString().ToLower().Contains(request.Keyword.ToLower()));
                }
                if (!request.UnHide)
                {
                    query = query.Where(c => c.IsDeleted == false);
                }
                switch (request.OrderBy)
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
                //
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
            catch
            {
                return new PagedResult<Unit> { TotalRecords = 0, PageSize = 20, PageIndex = 1, Items = new List<Unit>() };
            }
        }
    }
}
