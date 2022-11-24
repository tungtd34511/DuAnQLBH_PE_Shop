using App.Data.Ultilities.PagingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Ultilities.ViewModels
{
    public class ThongKeViewModel
    {
        public List<decimal> Revenues { get; set; }
        public int  TotalOrders { get; set; }
        public int TotalOrderConfirms { get; set; }
        public int TotalOrderShippings { get; set; }
        public int TotalOrderCanceleds { get; set; }
        public int TotalOrderSuccesss { get; set; }
        public List<ProductVariationVm> LowStocks { get; set; }
        public List<TopFiveVm> TopFive { get; set; }
    }
}
