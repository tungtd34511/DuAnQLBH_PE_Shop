using App.Business.Sevices.Orders;
using App.Data.Repositories.Orders;
using App.Data.Ultilities.Catalog.Orders;
using App.Data.Ultilities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Sevices.ThongKes
{
    public class ThongKeServices : IThongKeServices
    {
        private readonly IOrderRepositories _orderRepositories;

        public ThongKeServices( IOrderRepositories orderRepositories)
        {
            _orderRepositories = orderRepositories;
        }
        public Task<ThongKeViewModel> GetThongKe(GetThongKeRequest request)
        {
            return _orderRepositories.GetThongKe(request);
        }
    }
}
