using App.Data.Ultilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Ultilities.PagingModels
{
    public class ProductInPaging
    {
        public int Id { get; set; }
        public decimal Price { set; get; }
        public ProductStatus Status { get; set; }
        public string? Name { set; get; }
        public string? Description { set; get; }
    }
}
