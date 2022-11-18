using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Manufacturers;
using App.Data.Ultilities.Catalog.Units;
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
    }
}
