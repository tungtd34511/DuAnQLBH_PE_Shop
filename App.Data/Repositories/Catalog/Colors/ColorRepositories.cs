using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Colors;
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
    }
}
