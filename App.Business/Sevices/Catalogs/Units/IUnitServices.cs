using App.Data.Entities;
using App.Data.Ultilities.Catalog.Units;
using App.Data.Ultilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Sevices.Catalogs.Units
{
    public interface IUnitServices
    {
        Task<bool> Add(Unit unit);
        Task<bool> Update(Unit unit);
        Task<bool> ChangeStatus(Unit unit);
        Task<Unit> GetById(int id);
        Task<PagedResult<Unit>> GetPaging(GetPagingUnitRequest request);
    }
}
