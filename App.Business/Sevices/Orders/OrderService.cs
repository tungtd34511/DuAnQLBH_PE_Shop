using App.Data.Entities;
using App.Data.Repositories.Orders;
using App.Data.Repositories.Users;
using App.Data.Ultilities.Catalog.Orders;
using App.Data.Ultilities.Common;
using App.Data.Ultilities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Sevices.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepositories _orderRepositories;
        private readonly IOrderHistoryRepositories _orderHistoryRepositories;
        private readonly IUserDetailRepositories _userDetailRepositories;
        public OrderService(IOrderRepositories orderRepositories, IOrderHistoryRepositories orderHistoryRepositories, IUserDetailRepositories userDetailRepositories)
        {
            _orderRepositories = orderRepositories;
            _orderHistoryRepositories = orderHistoryRepositories;
            _userDetailRepositories = userDetailRepositories;
        }
        public async Task<PagedResult<OderInPagingVm>> GetPagingOrder(GetPagingOrderRequest request)
        {
            return await _orderRepositories.GetPagingOrder(request);
        }
        public async Task<OrderVm> GetOrderVmById(int id)
        {
            return await _orderRepositories.GetOrderVmById(id);
        }
        public async Task<Order> GetOrderById(int id)
        {
            return await _orderRepositories.GetAsync(new object[] { id });
        }
        public async Task<bool> UpdateOrder(Order order,OrderHistory orderHistory)
        {
            try
            {
                await _orderRepositories.UpdateOneAsync(order);
                await _orderHistoryRepositories.AddOneAsync(orderHistory);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> CanceledOrder(Order order, OrderHistory orderHistory)
        {
            try
            {
                await _orderRepositories.UpdateOneAsync(order);
                await _orderHistoryRepositories.AddOneAsync(orderHistory);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<UserDetail> GetDetailByuserID(Guid Id)
        {
            return await _userDetailRepositories.GetAsync(new object[] { Id });
        }
    }
}
