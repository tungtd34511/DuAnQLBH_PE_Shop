using App.Data.Ultilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Ultilities.Catalog.ProductVariation
{
    public class UpdateStockProductVariationRequest
    {
        public int Id { get; set; }
        public int Stock { get; set; }
    }
}
