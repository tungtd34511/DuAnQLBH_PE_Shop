using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Colors;
using App.Data.Ultilities.Catalog.ProductVariation;
using App.Data.Ultilities.Common;
using App.Data.Ultilities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Products
{
    public class ProductVariationRepositories : BaseRepositories<ProductVariation>, IProductVariationRepositories
    {
        private readonly QLBH_Context _context;
        public ProductVariationRepositories(QLBH_Context context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ChangeStatus(int pvId, bool status)
        {
            var pv = Entities.Find(pvId);
            if (pv == null)
                return false;
            pv.IsDeleted = status;
            Entities.Update(pv);
            return await _context.SaveChangesAsync()>0;
        }

        public async Task<List<ProductVariation>> GetByProductId(int pId)
        {
            return await Entities.Where(c=>c.ProductId== pId).ToListAsync();
        }
        public async Task<List<ProductVariationVm>> GetVMByProductId(int pId)
        {

            return await (from pv in Entities
                         join cl in _context.Colors on pv.ColorId equals cl.Id
                         join s in _context.Sizes on pv.SizeId equals s.Id
                         join pd in _context.ProductDetails on pv.ProductId equals pd.ProductId
                         where pv.IsDeleted == false && pv.Stock>0 && pv.ProductId == pId
                         select new ProductVariationVm()
                         {
                             SizeId= pv.SizeId,
                             SizeName = s.Name,
                             Stock = pv.Stock,
                             ColorId=pv.ColorId,
                             ColorName = cl.Name,
                             Id =pv.Id,
                             IsDeleted=pv.IsDeleted,
                             ProductId =pv.ProductId
                             ,
                             ProductName = pd.Name
                         }).ToListAsync();
        }
        public int MyProperty { get; set; }
        
        public async Task<PagedResult<ProductVariationVm>> GetPaging(GetPagingProductVariationRequest request)
        {
            //            Không sắp xếp
            //Theo mã(Tăng)
            //Theo mã(Giảm)
            //Theo tên sản phẩm(A-Z)
            //Theo tên sản phẩm(Z-A)
            //Theo màu(A -Z)
            //Theo màu(Z-A)
            //Theo kích cỡ(A - Z)
            //Theo kích cỡ(Z - A)
            //Theo so luong(A - Z)
            //Theo so luong(A - Z)
            //Theo trạng thái(Hiện - Ẩn)
            //Theo trạng thái(Ẩn - Hiện)
            try
            {
                var query = from pv in _context.ProductVariations
                            join c in _context.Colors on pv.ColorId equals c.Id
                            join s in _context.Sizes on pv.SizeId equals s.Id
                            join pd in _context.ProductDetails on pv.ProductId equals pd.ProductId
                            select new { pv, c, s, pd };
                if (!String.IsNullOrEmpty(request.Keyword))
                {
                    query = query.Where(c => c.pv.Id.ToString() == request.Keyword || c.pd.Name.ToLower().Contains(request.Keyword.ToLower()));
                }
                if (!request.UnHide)
                {
                    query = query.Where(c => c.pv.IsDeleted ==false);
                }
                switch (request.OrderBy)
                {
                    case 0:
                        break;
                    case 1:
                        query = query.OrderBy(c => c.pv.Id);
                        break;
                    case 2:
                        query = query.OrderByDescending(c => c.pv.Id);
                        break;
                    case 3:
                        query = query.OrderBy(c => c.pd.Name);
                        break;
                    case 4:
                        query = query.OrderByDescending(c => c.pd.Name);
                        break;
                    case 5:
                        query = query.OrderBy(c => c.c.Name);
                        break;
                    case 6:
                        query = query.OrderByDescending(c => c.c.Name);
                        break;
                    case 7:
                        query = query.OrderBy(c => c.s.Id);
                        break;
                    case 8:
                        query = query.OrderByDescending(c => c.s.Id);
                        break;
                    case 9:
                        query = query.OrderBy(c => c.pv.Stock);
                        break;
                    case 10:
                        query = query.OrderByDescending(c => c.pv.Stock);
                        break;
                    case 11:
                        query = query.OrderBy(c => c.pv.IsDeleted);
                        break;
                    case 12:
                        query = query.OrderByDescending(c => c.pv.IsDeleted);
                        break;
                }
                var total = await query.CountAsync();
                var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .Select(x => new ProductVariationVm()
                    {
                        ColorId = x.c.Id,
                        ColorName = x.c.Name,
                        Id = x.pv.Id,
                        SizeId = x.pv.SizeId,
                        SizeName = x.s.Name,
                        Stock = x.pv.Stock,
                        IsDeleted = x.pv.IsDeleted,
                        ProductId = x.pv.Id,
                        ProductName = x.pd.Name
                    }).ToListAsync();
                //4. Select 

                var pagedResult = new PagedResult<ProductVariationVm>()
                {
                    TotalRecords = total,
                    PageSize = request.PageSize,
                    PageIndex = request.PageIndex,
                    Items = data
                };
                return pagedResult;
            }
            catch
            {
                return new() { Items = new(), PageSize = 20, PageIndex = 1, TotalRecords = 0 };
            }
        }

        public async Task<bool> Contain(ProductVariation request)
        {
            return await Entities.AnyAsync(c=>c.ProductId== request.ProductId&&c.SizeId==request.SizeId&&c.ColorId==request.ColorId);
        }
        public async Task<ProductVariationVm> GetByQR(int id)
        {
            var pv = await Entities.FirstOrDefaultAsync(c=>c.Id==id);
            if (pv == null)
            {
                return new();
            }
            else
            {
                return new ProductVariationVm()
                {
                    Id = pv.Id,
                    SizeId = pv.SizeId,
                    ColorName = _context.Colors.FirstOrDefault(c => c.Id == pv.ColorId).Name,
                    ColorId = pv.ColorId,
                    ProductId= pv.ProductId,
                    SizeName = _context.Sizes.FirstOrDefault(c=>c.Id==pv.SizeId).Name
                };
            }
        }
    }
}
