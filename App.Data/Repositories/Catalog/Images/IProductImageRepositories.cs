using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Catalog.Images
{
    public interface IProductImageRepositories : IBaseRepositories<ProductImage>
    {
        Task<bool> DeleteManyByRequest(DeleteImageRequest request);
    }
}
