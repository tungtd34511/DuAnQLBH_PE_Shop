using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Manufacturers;
using App.Data.Ultilities.Catalog.Units;
using App.Data.Ultilities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Catalog.Manufacturers
{
    public class ManufacturerRepositories : BaseRepositories<Manufacturer>, IManufacturerRepositories
    {
        public ManufacturerRepositories(QLBH_Context context) : base(context)
        {
        }

        public async Task<List<ManufacturerInCreateProduct>> GetAllForCreate()
        {
            return await (Entities.Where(c => c.IsDeleted == false).Select(c => new ManufacturerInCreateProduct() { Id = c.Id, Name = c.Name }).ToListAsync());
        }
        public async Task<PagedResult<Manufacturer>> GetPaging(GetPagingManufactureRequest request)
        {
            var query = Entities.Where(c => c.IsDeleted == false);
            var total = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize).ToListAsync();
            //4. Select 

            var pagedResult = new PagedResult<Manufacturer>()
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
