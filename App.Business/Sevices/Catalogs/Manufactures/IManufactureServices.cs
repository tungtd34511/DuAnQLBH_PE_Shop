using App.Data.Entities;
using App.Data.Ultilities.Catalog.Manufacturers;
using App.Data.Ultilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Sevices.Catalogs.Manufactures
{
    public interface IManufactureServices
    {
        Task<bool> Add(Manufacturer manufacturer);
        Task<bool> Update(Manufacturer manufacturer);
        Task<bool> ChangeStatus(Manufacturer manufacturer);
        Task<Manufacturer> GetManufacturerById(int id);
        Task<PagedResult<Manufacturer>> GetPaging(GetPagingManufactureRequest request);
    }
}
