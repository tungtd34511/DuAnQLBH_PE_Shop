using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Ultilities.ViewModels
{
    public class ProductInOrderVm
    {
        public string Name { get; set; }
        public int Quantity { set; get; }
        public decimal Price { set; get; } // giá đã giảm
    }
}
