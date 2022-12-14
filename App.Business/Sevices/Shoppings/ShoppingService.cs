using App.Business.Models.Products;
using App.Data.Entities;
using App.Data.Repositories.Carts;
using App.Data.Repositories.Catalog.Categories;
using App.Data.Repositories.Catalog.Colors;
using App.Data.Repositories.Catalog.Sizes;
using App.Data.Repositories.Customers;
using App.Data.Repositories.Orders;
using App.Data.Repositories.Products;
using App.Data.Repositories.Promotions;
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
    public class ShoppingService : IShoppingService
    {
        private readonly IProductRepositories _productRepositories;
        private readonly IProductVariationRepositories _productVariationRepositories;
        private readonly ICartRepositories _cartRepositories;
        private readonly IProductInCartRepositories _productInCartRepositories;
        private readonly IOrderRepositories _orderRepositories;
        private readonly ICustomerRepositories _customerRepositories;
        private readonly IColorRepositories _colorRepositories;
        private readonly ISizeRepositories _sizeRepositories;
        private readonly ICategoryRepositories _categoryRepositories;
        private readonly IPromotionRepositories _promotionRepositories;
        public ShoppingService(IProductRepositories productRepositories, IProductVariationRepositories productVariationRepositories, ICartRepositories cartRepositories, IProductInCartRepositories productInCartRepositories, IOrderRepositories orderRepositories, ICustomerRepositories customerRepositories, ICategoryRepositories categoryRepositories, ISizeRepositories sizeRepositories, IColorRepositories colorRepositories, IPromotionRepositories promotionRepositories)
        {
            _productRepositories = productRepositories;
            _productVariationRepositories = productVariationRepositories;
            _cartRepositories = cartRepositories;
            _productInCartRepositories = productInCartRepositories;
            _orderRepositories = orderRepositories;
            _customerRepositories = customerRepositories;
            _categoryRepositories = categoryRepositories;
            _sizeRepositories = sizeRepositories;
            _colorRepositories = colorRepositories;
            _promotionRepositories = promotionRepositories;
        }

        public async Task<PagedResult<ProductInShoppingVm>> GetProducts(GetPagingShoppingRequest request)
        {
            var pagedResult = await _productRepositories.GetPagingForShopping(request);
            Promotions = await _promotionRepositories.GetPromotionActive();
            var p = pagedResult.Items[0];

            try
            {
                pagedResult.Items = pagedResult.Items.Select( p => new ProductInShoppingVm() { Id = p.Id, Name = p.Name, Price = p.Price, ThumbailImage = p.ThumbailImage, DiscountPercent = GetPromotion(p) }).ToList();
            }
            catch {

            }
            return pagedResult;
        }
        public List<Promotion> Promotions { get; set; }
        public int GetPromotion(ProductInShoppingVm pv)
        {
            foreach(var pm in Promotions)
            {
                if(pm.ProductIds.Split(" ").Contains(pv.Id.ToString()) || pv.Cats.Any(c => pm.ProductCategoryIds.Split(" ").Contains(c)) || pm.ApplyForAll)
                {
                    return pm.DiscountPercent;
                }
            }
            return 0;
        }
        public async Task<List<ProductVariationVm>> GetPvVMByProductId(int pId) // lấy pv viewmodel
        {
            return  await _productVariationRepositories.GetVMByProductId(pId); ;
        }
        public async Task<List<CartItemViewModel>> GetItemByCartId(int cartId)
        {
            return await _productInCartRepositories.GetItemByCartId(cartId);
        }
        public async Task<IEnumerable<Cart>> GetAllCarts()
        {
            return await _cartRepositories.GetAllAsync();
        }

        public async Task<bool> AddCart(Cart cart)
        {
            return await _cartRepositories.AddOneAsync(cart);
        }

        public async Task<bool> UpdateCart(Cart request)
        {
            try
            {
                var cart = await _cartRepositories.GetAsync(new object[] { request.Id });
                cart.ShipEmail = request.ShipEmail;
                cart.ShipPhoneNumber = request.ShipPhoneNumber;
                cart.CustomerName = request.CustomerName;
                cart.ShipAddress = request.ShipAddress;
                cart.CustomerMoney = request.CustomerMoney;
                cart.Description = request.Description;
                var result = await _cartRepositories.UpdateOneAsync(cart);
                var cartitems =  await _productInCartRepositories.GetByCartID(request.Id);
                await _productInCartRepositories.DeleteManyAsync(cartitems.Where(c => !request.ProductInCarts.Select(d => new { d.ProductVariationId, d.CartId }).Contains(new { c.ProductVariationId, c.CartId })));
                await _productInCartRepositories.UpdateManyAsync(request.ProductInCarts);
                return true;
            }
            catch
            {
                return false;
            }
               
        }

        public async Task<bool> AddOrder(Order order)
        {
            return await _orderRepositories.AddOneAsync(order);
        }
        public async Task<bool> RemoveCart(Cart cart)
        {
            try
            {
                if (cart.ProductInCarts != null)
                {
                    if (cart.ProductInCarts.Count > 0)
                    {
                        await _productInCartRepositories.DeleteManyAsync(cart.ProductInCarts);
                        
                    }
                }
                await _cartRepositories.DeleteOneAsync(new object[] { cart.Id });
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<List<ProductInCart>> GetProductInCarts(int cartid)
        {
            return await _productInCartRepositories.GetByCartID(cartid);
        }

        public async Task<IEnumerable<Customer>> GetByPhoneNumber(string phonenumber)
        {
            return await _customerRepositories.GetByPhoneNumber(phonenumber);
        }
        public async Task<DataForProductFilter> GetDataForFilter()
        {
            return new DataForProductFilter()
            {
                Colors = await _colorRepositories.GetAllForCreate(),
                Sizes = await _sizeRepositories.GetAllForCreate(),
                Categories = await _categoryRepositories.GetAllForCreate(),
            };
        }
        public async Task<string> Validate(string phonenumber)
        {
            return await _customerRepositories.Validate(phonenumber);
        }

        public async Task<bool> AddCustomer(Customer customer)
        {
            return await _customerRepositories.AddOneAsync(customer);
        }
        public async Task<ProductInShoppingVm> GetProductShoppingById(int id)
        {
            return await _productRepositories.GetProductShoppingById(id);
        }
		 public async Task<ProductVariationVm> GetByQR(int id)
        {
            return await _productVariationRepositories.GetByQR(id);
        }
	}
}
