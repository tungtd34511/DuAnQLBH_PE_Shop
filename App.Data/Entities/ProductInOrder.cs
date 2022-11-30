using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class ProductInOrder
    {
        public int OrderId { set; get; }
        public int ProductVariationId { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; } // giá đã giảm
        public decimal Lai { set; get; } = 0;
        public DateTime Created { set; get; }
        public virtual Order Order { get; set; }
        public virtual ProductVariation ProductVariation { get; set; }
    }
}
