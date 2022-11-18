using App.Data.Ultilities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Ultilities.Catalog.Product
{
    public class AddProductRequest
    {
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public ProductStatus Status { get; set; }
        public string Name { set; get; }
        public string? Description { set; get; }
        public string? Details { set; get; }
        public Gender Gender { set; get; }
        public int UnitId { get; set; }
        public int ManufacturerId { set; get; }
        public List<string> Images { get; set; } = new List<string>();
        public List<int> categoryIds { get; set; } = new();
    }
}
