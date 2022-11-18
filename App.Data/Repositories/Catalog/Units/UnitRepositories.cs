using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Units;
using Microsoft.EntityFrameworkCore;

namespace App.Data.Repositories.Catalog.Units
{
    public class UnitRepositories : BaseRepositories<Unit>, IUnitRepositories
    {
        public UnitRepositories(QLBH_Context context) : base(context)
        {
        }

        public async Task<List<UnitForCreate>> GetAllForCreate()
        {
            return await (Entities.Where(c => c.IsDeleted == false).Select(c => new UnitForCreate() { Id = c.Id, Name = c.Name }).ToListAsync());
        }
    }
}
