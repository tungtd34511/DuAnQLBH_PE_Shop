using App.Data.Entities;
using App.Data.Ultilities.Catalog.Colors;
using App.Data.Ultilities.Catalog.Units;
using App.Data.Ultilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Sevices.Catalogs.Colors
{
    public interface IColorService
    {
        Task<bool> Add(Color color);
        Task<bool> Update(Color color);
        Task<bool> ChangeStatus(Color color);
        Task<Color> GetById(string id);
        Task<PagedResult<Color>> GetPaging(GetColorPagingRequest request);
        Task<string> Validate(string id, string Name);
    }
}
