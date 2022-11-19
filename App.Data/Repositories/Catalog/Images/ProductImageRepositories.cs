using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Catalog.Images
{
    public class ProductImageRepositories : BaseRepositories<ProductImage>, IProductImageRepositories
    {
        public ProductImageRepositories(QLBH_Context context) : base(context)
        {
        }

        public async Task<bool> DeleteManyByRequest(DeleteImageRequest request)
        {
            var paths = request.Paths.ToList();
            var imgs = Entities.Where(c=>c.ProductId == request.ProductId&& paths.Contains(c.ImagePath)).ToList();
            return await DeleteManyAsync(imgs);
        }
    }
}
