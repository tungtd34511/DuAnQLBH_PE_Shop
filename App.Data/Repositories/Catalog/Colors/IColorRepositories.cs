using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Colors;
using App.Data.Ultilities.Common;
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
        Task<PagedResult<Color>> GetPaging(GetColorPagingRequest request);
        Task<string> Validate(string id, string Name);
    }
}