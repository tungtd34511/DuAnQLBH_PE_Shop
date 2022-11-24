using App.Data.Entities;
using App.Data.Ultilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Ultilities.ViewModels
{
    public class OderInPagingVm
    {
        public int Id { get; set; }
        public DateTime Created { set; get; }
        public decimal Total { set; get; } // tổng tiền của đơn
        public OrderStatus Status { set; get; }
        public bool IsShipping { set; get; } = false;
        public string? CustomerName { get; set; }
        public string UserName { get; set; } // tên nhân viên
    }
}
