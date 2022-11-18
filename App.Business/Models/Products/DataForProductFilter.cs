using App.Data.Ultilities.Catalog.Categories;
using App.Data.Ultilities.Catalog.Colors;
using App.Data.Ultilities.Catalog.Sizes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Models.Products
{
    public class DataForProductFilter
    {
        public List<ColorsForCreate> Colors { get; set; }
        public List<SizesForCreate> Sizes { get; set; }
        public List<CategoryForCreate> Categories { get; set; }
    }
}
