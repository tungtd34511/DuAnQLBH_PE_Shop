using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Orders;
using App.Data.Ultilities.Common;
using App.Data.Ultilities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Orders
{
    public interface IOrderRepositories : IBaseRepositories<Order>
    {
        Task<PagedResult<OderInPagingVm>> GetPagingOrder(GetPagingOrderRequest request);
        Task<OrderVm> GetOrderVmById(int id);
        Task<ThongKeViewModel> GetThongKe(GetThongKeRequest request);
    }
}
