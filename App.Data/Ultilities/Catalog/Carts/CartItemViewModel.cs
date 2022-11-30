using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Ultilities.Catalog.Carts
{
    public class CartItemViewModel
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int PvId { get; set; }
        public string ColorId { get; set; }
        public string ColorName { get; set; }
        public string  SizeId { get; set; }
        public string Sizename { get; set; }
        public string? ThumbailImage{ get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
        public int DiscountPercent { get; set; }
    }
}
