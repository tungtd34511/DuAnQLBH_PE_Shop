using App.Data.Ultilities.Catalog.Orders;
using App.Data.Ultilities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Sevices.ThongKes
{
    public interface IThongKeServices
    {
        Task<ThongKeViewModel> GetThongKe(GetThongKeRequest request);
    }
}
