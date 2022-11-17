using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Ultilities.Catalog.ProductVariation
{
    public class AddProductVariationRequest
    {
        public int ProductId { get; set; }
        public string ColorId { get; set; }
        public string SizeId { get; set; }
        public int Stock { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
