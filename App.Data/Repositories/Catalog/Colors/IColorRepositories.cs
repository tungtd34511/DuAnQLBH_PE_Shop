using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Catalog.Colors
{
    public interface IColorRepositories : IBaseRepositories<Color>
    {
        Task<List<ColorsForCreate>> GetAllForCreate();
    }
}