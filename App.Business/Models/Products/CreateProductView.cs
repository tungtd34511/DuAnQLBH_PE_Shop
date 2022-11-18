using App.Data.Entities;
using App.Data.Ultilities.Catalog.Categories;
using App.Data.Ultilities.Catalog.Manufacturers;
using App.Data.Ultilities.Catalog.Units;

namespace App.Business.Models.Products
{
    public class CreateProductView
    {
        public List<CategoryForCreate> categories { get; set; }
        public List<ManufacturerInCreateProduct> Manufacturers { get; set; }
        public List<UnitForCreate> Units { get; set; }
    }
}
