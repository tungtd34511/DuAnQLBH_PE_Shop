using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class ProductVariation
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string ColorId { get; set; }
        public virtual Color Color { get; set; }
        public  string SizeId { get; set; }
        public virtual Size Size { get; set; }
        public int Stock { get; set; }
        public bool IsDeleted { get; set; } // Dòng này dùng để ẩn thay cho việc xóa
        public virtual List<ProductInOrder> ProductInOrders { get; set; }

        public virtual List<ProductInCart> ProductInCarts { get; set; }
    }
}
