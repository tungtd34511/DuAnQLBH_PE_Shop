using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Carts
{
    public interface IProductInCartRepositories : IBaseRepositories<ProductInCart>
    {
        Task<List<CartItemViewModel>> GetItemByCartId(int cartId);
        Task<List<ProductInCart>> GetByCartID(int cartId);
    }
}
