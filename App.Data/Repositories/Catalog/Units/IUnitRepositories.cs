using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Catalog.Units
{
    public interface IUnitRepositories : IBaseRepositories<Unit>
    {
        Task<List<UnitForCreate>> GetAllForCreate();
    }
}
