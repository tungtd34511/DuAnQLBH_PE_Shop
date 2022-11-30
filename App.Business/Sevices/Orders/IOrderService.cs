using App.Data.Entities;
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
    public interface IOrderService
    {
        Task<PagedResult<OderInPagingVm>> GetPagingOrder(GetPagingOrderRequest request);
        Task<OrderVm> GetOrderVmById(int id);
        Task<Order> GetOrderById(int id);
        Task<bool> UpdateOrder(Order order, OrderHistory orderHistory);
        Task<bool> CanceledOrder(Order order, OrderHistory orderHistory);
        Task<UserDetail> GetDetailByuserID(Guid Id);
    }
}
