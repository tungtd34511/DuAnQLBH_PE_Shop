using App.Data.Entities;
using App.Data.Ultilities.Catalog.ProductVariation;
using App.Data.Ultilities.Catalog.Sizes;
using App.Data.Ultilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Sevices.Catalogs.Sizes
{
    public interface ISizeService
    {
        Task<bool> Add(Size size);
        Task<bool> Update(Size size);
        Task<bool> ChangeStatus(Size size);
        Task<Size> GetById(string id);
        Task<PagedResult<Size>> GetPaging(GetSizePagingRequest request);
        Task<string> Validate(string id, string name);
    }
}
