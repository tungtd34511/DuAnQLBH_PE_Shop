using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Carts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Carts
{
    public class ProductInCartRepositories : BaseRepositories<ProductInCart>, IProductInCartRepositories
    {
        private readonly QLBH_Context _context;
        public ProductInCartRepositories(QLBH_Context context) : base(context)
        {
            _context = context;
        }
        public async Task<List<CartItemViewModel>> GetItemByCartId(int cartId)
        {
            var data = await (from a in _context.ProductInCarts
                              join b in _context.ProductVariations on a.ProductVariationId equals b.Id
                              join p in _context.Products on b.ProductId equals p.Id
                              join pd in _context.ProductDetails on p.Id equals pd.ProductId
                              join c in _context.Colors on b.ColorId equals c.Id
                              join s in _context.Sizes on b.SizeId equals s.Id
                              where a.CartId == cartId
                              select new CartItemViewModel()
                              {
                                  CartId = a.CartId,
                                  ColorId = b.ColorId,
                                  ColorName = c.Name,
                                  Price = p.Price,
                                  SizeId = s.Id,
                                  Sizename = s.Name,
                                  ProductId = p.Id,
                                  PvId = b.Id,
                                  Quantity = a.Quantity,
                                  ProductName = pd.Name,
                                  ThumbailImage = _context.ProductImages.FirstOrDefault(c => c.ProductId == p.Id).ImagePath
                              }).ToListAsync();
            return data;
        }
        public async Task<List<ProductInCart>> GetByCartID(int cartId)
        {
            return await Entities.Where(c => c.CartId == cartId).ToListAsync();
        }
    }
}
