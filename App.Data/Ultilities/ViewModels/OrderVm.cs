using App.Data.Entities;
using App.Data.Ultilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Ultilities.ViewModels
{
    public class OrderVm
    {
        public int Id { get; set; }
        public DateTime Created { set; get; }
        public string? ShipName { set; get; }
        public string? ShipAddress { set; get; }
        public string? ShipEmail { set; get; }
        public string? ShipPhoneNumber { set; get; }
        public decimal Total { set; get; } // tổng tiền của đơn
        public string? Description { set; get; }
        public OrderStatus Status { set; get; }
        public bool IsShipping { set; get; } = false;
        public int? CustomerId { get; set; }
        public Guid? UserCreatedId { get; set; }
        public string? UserName { get; set; }
        public List<ProductInOrderVm> Products { get; set; }
        public List<OrderHistoryVm> Histories { get; set; }
    }
}
