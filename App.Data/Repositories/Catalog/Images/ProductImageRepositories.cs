using App.Data.Context;
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
    public class ProductImageRepositories : BaseRepositories<ProductImage>, IProductImageRepositories
    {
        private readonly QLBH_Context _context;
        public ProductImageRepositories(QLBH_Context context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> DeleteManyByRequest(DeleteImageRequest request)
        {
            var imgs = from a in _context.ProductImages
                       join b in request.Paths on a.ImagePath equals b
                       select a;
            return await DeleteManyAsync(imgs);
        }
    }
}
