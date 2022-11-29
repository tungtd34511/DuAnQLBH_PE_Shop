using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
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
using App.Data.Ultilities.Recursives;
using App.Data.Ultilities.Catalog.Products;

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
            var list = new List<ProductInQuery>();
            int totalRow = 0;
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
                switch (request.OderBy)
                {
                    case 1:
                        break;
                    case 2:
                        query = query.OrderByDescending(c => c.p.Id);
                        break;
                    case 3:
                        query = query.OrderBy(c => c.pd.Name);
                        break;
                    case 4:
                        query = query.OrderByDescending(c => c.pd.Name);
                        break;
                    case 5:
                        query = query.OrderBy(c => c.p.Price);
                        break;
                    case 6:
                        query = query.OrderByDescending(c => c.p.Price);
                        break;
                    case 7:
                        query = query.OrderByDescending(c => c.p.Status);
                        break;
                    case 8:
                        query = query.OrderBy(c => c.p.Status);
                        break;
                    case 9:
                        query = query.OrderBy(c => c.p.DateCreated);
                        break;
                    case 10:
                        query = query.OrderByDescending(c => c.p.DateCreated);
                        break;
                }
            }
            //

            list = await query.Select(c => new ProductInQuery() { Product = c.p, ProductDetail = c.pd }).ToListAsync();
            var data = new List<ProductInPaging>();
            if (request.Checks != null && request.Checks.Any(c => c == true))
            {
                listCBox = request.Checks;
                list = list.Where(c => GetResultFilter(c.Product.Id)).ToList();
                totalRow = list.Count;
                data = list.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductInPaging()
                {
                    Id = x.Product.Id,
                    Name = x.ProductDetail.Name,
                    Status = x.Product.Status,
                    Description = x.ProductDetail.Description,
                    Price = x.Product.Price
                }).ToList();
            }
            else
            {
                totalRow = await query.CountAsync();
                
            }
            //3.Paging

            data = list.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductInPaging()
                {
                    Id = x.Product.Id,
                    Name = x.ProductDetail.Name,
                    Status = x.Product.Status,
                    Description = x.ProductDetail.Description,
                    Price = x.Product.Price
                }).ToList();
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
        public bool[] listCBox { get; set; }
        public bool GetResultFilter(int productid)
        {//Sử dụng đệ quy lấy kết quả cho list điều kiện
            var dequy = new LstCheckRecursive();
            int index = 0;
            List<bool> listMain = new List<bool>();//Tổng kết các kết quả
            //{ "GIỚI TÍNH", "GIÁ", "NHÓM HÀNG", "TÌNH TRẠNG", "THƯƠNG HIỆU"};
            //List điều kiện
            //
            List<bool> listkq3 = new List<bool>();
            var cartergories = _context.Categories.Where(c => c.IsDeleted == false).Select(c => c.Id).ToList();
            var productcategories = _context.ProductInCategories.Where(c => c.ProductId == productid).Select(c => c.CategoryId).ToList();
            foreach (var a in cartergories)
            {
                if (listCBox[index++])
                {
                    listkq3.Add(productcategories.Contains(a));
                }
            }
            if (listkq3.Count > 0)
            {
                listMain.Add(dequy.GetBoolHoac(listkq3)); //sử dụng get bool2 vì cùng một nhóm sẽ dùng toán tử hoặc ||
            }
            //
            List<bool> listkq4 = new List<bool>();
            var colors = _context.Colors.Where(c => c.IsDeleted == false).Select(c => c.Id).ToList();
            var PVs = _context.ProductVariations.Where(c => c.ProductId == productid).Select(c => c.ColorId).ToList();
            foreach (var a in colors)
            {
                if (listCBox[index++])
                {
                    listkq4.Add(PVs.Contains(a));
                }
            }
            if (listkq4.Count > 0)
            {
                listMain.Add(dequy.GetBoolHoac(listkq4)); //sử dụng get bool2 vì cùng một nhóm sẽ dùng toán tử hoặc ||
            }
            //
            List<bool> listkq5 = new List<bool>();
            var sizes = _context.Sizes.Where(c => c.IsDeleted == false).Select(c => c.Id).ToList();
            var PV2s = _context.ProductVariations.Where(c => c.ProductId == productid).Select(c => c.SizeId).ToList();
            foreach (var a in sizes)
            {
                if (listCBox[index++])
                {
                    listkq5.Add(PV2s.Contains(a));
                }
            }
            if (listkq5.Count > 0)
            {
                listMain.Add(dequy.GetBoolHoac(listkq5)); //sử dụng get bool2 vì cùng một nhóm sẽ dùng toán tử hoặc ||
            }
            //
            List<bool> listkq2 = new List<bool>();
            List<decimal> lstGia = new() { 199000, 299000, 399000, 499000, 799000, 999000 };
            var product = Entities.FirstOrDefault(c => c.Id == productid);
            for (int i = 0; i <= lstGia.Count; i++)//đệt mợ cái bug khốn nạn sai dấu >=
            {
                if (listCBox[index++])
                {
                    if (product != null)
                    {
                        if (i == 0)
                        {
                            listkq2.Add(product.Price < lstGia[i]);
                        }
                        else if (i == lstGia.Count)
                        {
                            listkq2.Add(product.Price > lstGia[lstGia.Count - 1]);
                        }
                        else
                        {
                            listkq2.Add((product.Price >= lstGia[i - 1]) && (product.Price <= lstGia[i]));
                        }
                    }
                }
            }
            if (listkq2.Count > 0)
            {
                listMain.Add(dequy.GetBoolHoac(listkq2)); //sử dụng get bool2 vì cùng một nhóm sẽ dùng toán tử hoặc ||
            }

            if (listMain.Count > 0)
            {
                return dequy.GetBoolVa(listMain);//ĐỆ quy giửa các nhóm đệ quy là và và
            }
            else
            {
                return true;//Hiện thị tất cả nếu không check box nào đc chọn
            }
        }

        public async Task<PagedResult<ProductInShoppingVm>> GetPagingForShopping(GetPagingShoppingRequest request)
        {
            var query = from p in _context.Products
                        join pd in _context.ProductDetails on p.Id equals pd.ProductId
                        where _context.ProductVariations.Where(c => c.IsDeleted == false && c.Stock > 0).Select(c => c.ProductId).Contains(p.Id)
                        select new { p, pd, img=_context.ProductImages.FirstOrDefault(c=>c.ProductId==p.Id)};
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.pd.Name.ToLower().Contains(request.Keyword.ToLower())||x.p.Id.ToString()==request.Keyword);
            if (request.OderBy != 0) // oder by dropdowlisst in Form ProductIndex
            {
                switch (request.OderBy)
                {
                    case 1:
                        query = query.OrderBy(c => c.pd.Name);
                        break;
                    case 2:
                        query = query.OrderByDescending(c => c.pd.Name);
                        break;
                    case 3:
                        query = query.OrderBy(c => c.p.Price);
                        break;
                    case 4:
                        query = query.OrderByDescending(c => c.p.Price);
                        break;
                    case 5:
                        query = query.OrderByDescending(c => c.p.Id);
                        break;
                    case 6:
                        query = query.OrderBy(c => c.p.Id);
                        break;
                }
            }
            //
            var list = new List<ProductInShoppingVm>();
            int totalrecords =0;
            //
            if (request.Checks != null && request.Checks.Any(c => c == true))
            {
                listCBox = request.Checks;
                
                var data = query.ToList().Where(c => GetResultFilter(c.p.Id));
                totalrecords =data.Count();
                list = data.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductInShoppingVm()
                {
                    Id = x.p.Id,
                    Name = x.pd.Name,
                    Price = x.p.Price,
                    ThumbailImage = x.img.ImagePath
                }).ToList();
            }
            else
            {
                totalrecords = await query.CountAsync();

                list = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductInShoppingVm()
                {
                    Id = x.p.Id,
                    Name = x.pd.Name,
                    Price = x.p.Price,
                    ThumbailImage = x.img.ImagePath
                }).ToListAsync();
            }
            
            //4. Select 

            var pagedResult = new PagedResult<ProductInShoppingVm>()
            {
                TotalRecords= totalrecords,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = list
            };
            return pagedResult;
        }
    }
}
