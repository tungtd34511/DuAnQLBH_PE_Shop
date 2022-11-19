using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Ultilities.Catalog.Products
{
    public class ProductInQuery
    {
        public Product Product { get; set; }
        public ProductDetail ProductDetail { get; set; }
    }
}
