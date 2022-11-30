using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Promotion;
using App.Data.Ultilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Promotions
{
    public interface IPromotionRepositories : IBaseRepositories<Promotion>
    {
        Task<PagedResult<Promotion>> GetPaging(GetPromotionPagingRequest request);
        Task<string> Validation(string Name);
        Task<List<Promotion>> GetPromotionActive();
    }
}
