using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Product;
using App.Data.Ultilities.Common;
using App.Data.Ultilities.PagingModels;
using App.Data.Ultilities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data.Ultilities.ViewModels;

namespace App.Data.Repositories.Products
{
    public class ProductRepositories : BaseRepositories<Product>, IProductRepositories
    {
        private readonly QLBH_Context _context;
        public ProductRepositories(QLBH_Context context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedResult<ProductInPaging>> GetAllPaging1(GetPagingProductRequest request) // Lấy cho trang Quản lý sản phẩm
        {
            //1. Select join
            var query = from p in _context.Products
                        join pd in _context.ProductDetails on p.Id equals pd.ProductId
                        select new { p, pd };

            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.pd.Name.ToLower().Contains(request.Keyword.ToLower()));

            if (!request.UnHide) // Nếu không bỏ ẩn
            {
                query = query.Where(c => c.p.Status == ProductStatus.Active);
            }
            if (request.OderBy != 0) // oder by dropdowlisst in Form ProductIndex
            {
                //Oder by
            }
            if (request.Checks.Any(c => c))
            {
                // Lọc theo nhiều giá trị
            }
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductInPaging()
                {
                    Id = x.p.Id,
                    Name = x.pd.Name,
                    Status = x.p.Status,
                    Description = x.pd.Description,
                    Price = x.p.Price
                }).ToListAsync();
            //4. Select 

            var pagedResult = new PagedResult<ProductInPaging>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<ProductVm> GetById(int productId)
        {
            var item = await _context.Products.FindAsync(productId);
            if (item == null)
                return null;
            var productdetail = await _context.ProductDetails.FirstOrDefaultAsync(c => c.ProductId == productId);

            var unit = await _context.Units.FirstOrDefaultAsync(c => c.Id == productdetail.UnitId);
            var manufacturer = await _context.Manufacturers.FirstOrDefaultAsync(c => c.Id == productdetail.ManufacturerId);

            var categories = await (from c in _context.Categories
                                    join pic in _context.ProductInCategories on c.Id equals pic.CategoryId
                                    where pic.ProductId == productId
                                    select c.Id).ToListAsync();

            var images = await _context.ProductImages.Where(x => x.ProductId == productId).Select(c => c.ImagePath).ToListAsync();
            return new ProductVm()
            {
                Status = item.Status,
                Categories = categories,
                Images = images,
                DateCreated = item.DateCreated,
                Description = productdetail.Description,
                Details = productdetail.Details,
                Gender = productdetail.Gender,
                ManufacturerId = manufacturer.Id,
                ManufacturerName = manufacturer.Name,
                Id = item.Id,
                Name = productdetail.Name,
                OriginalPrice = item.OriginalPrice,
                Price = item.Price,
                UnitId = unit.Id,
                UnitName = unit.Name,
            };
        }
    }
}
