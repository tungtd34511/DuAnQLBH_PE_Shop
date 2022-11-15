using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class ProductInCart
    {
        public int CartId { set; get; }
        public int ProductVariationId { set; get; }
        public int Quantity { set; get; }
        public virtual Cart Cart { get; set; }
        public virtual ProductVariation ProductVariation { get; set; } // sẽ không lưu giá
    }
}
