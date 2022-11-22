using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Ultilities.Catalog.Carts
{
    public class AddToCartRequest
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public int PvId { get; set; }
        public string ColorId { get; set; }
        public string ColorName { get; set; }
        public string SizeId { get; set; }
        public string SizeName { get; set; }
        public int Quantity { get; set; }
    }
}
