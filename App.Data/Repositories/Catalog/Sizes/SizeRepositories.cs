using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Repositories.Catalog.Units;
using App.Data.Ultilities.Catalog.Colors;
using App.Data.Ultilities.Catalog.Sizes;
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
    }
}
