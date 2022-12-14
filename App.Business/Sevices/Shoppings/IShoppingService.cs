using App.Business.Models.Products;
using App.Data.Entities;
using App.Data.Ultilities.Catalog.Carts;
using App.Data.Ultilities.Catalog.Products;
using App.Data.Ultilities.Common;
using App.Data.Ultilities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Sevices.Shoppings
{
    public interface IShoppingService
    {
        Task<PagedResult<ProductInShoppingVm>> GetProducts(GetPagingShoppingRequest request);
        Task<List<ProductVariationVm>> GetPvVMByProductId(int pId);
        Task<List<CartItemViewModel>> GetItemByCartId(int cartId);
        Task<IEnumerable<Cart>> GetAllCarts();
        Task<bool> AddCart(Cart cart);
        Task<bool> UpdateCart(Cart cart);
        Task<bool> AddOrder(Order order);
        Task<bool> RemoveCart(Cart cart);
        Task<List<ProductInCart>> GetProductInCarts(int cartid);
        Task<IEnumerable<Customer>> GetByPhoneNumber(string phonenumber);
        Task<DataForProductFilter> GetDataForFilter();
        Task<string> Validate(string phonenumber);
        Task<bool> AddCustomer(Customer customer);
        Task<ProductInShoppingVm> GetProductShoppingById(int id);
        Task<ProductVariationVm> GetByQR(int id);

	}
}
