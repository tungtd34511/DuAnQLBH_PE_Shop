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
            try
            {
                var query = Entities.Select(c => c);
                //            Không sắp xếp
                //Theo mã(Tăng)
                //Theo mã(Giảm)
                //Theo tên(A-Z)
                //Theo tên(Z-A)
                //Theo trạng thái(Inactive - Active)
                //Theo trạng thái(Active - Inactive)

                if (!String.IsNullOrEmpty(request.Keyword))
                {
                    query = query.Where(c => c.Name.ToLower().Contains(request.Keyword.ToLower()));
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
            catch
            {
                return new PagedResult<Manufacturer> { TotalRecords = 0, PageSize = 20, PageIndex = 1, Items = new() };
            }
        }
        public async Task<string> Valiate(string name)
        {
            if (await Entities.AnyAsync(c => c.Name.ToLower() == name))
            {
                return "Tên nhà sản xuất đã tồn tại !\n";
            }
            else return "";
        }
    }
}
