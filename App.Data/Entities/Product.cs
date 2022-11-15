using App.Data.Ultilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public decimal Price { set; get; } // Sẽ là giá đã bao gồm thuế
        public decimal OriginalPrice { set; get; }
        public DateTime DateCreated { set; get; }
        public ProductStatus Status { get; set; }
        public virtual List<ProductInCategory> ProductInCategories { get; set; }
        public virtual List<ProductImage> ProductImages { get; set; }
        public virtual List<ProductVariation> ProductVariations { get; set; }
        public virtual ProductDetail ProductDetail { get; set; }
    }
}
