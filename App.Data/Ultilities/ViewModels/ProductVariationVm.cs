using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Ultilities.ViewModels
{
    public class ProductVariationVm
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ColorId { get; set; }
        public string ColorName { get; set; }
        public string SizeId { get; set; }
        public string SizeName { get; set; }
        public int Stock { get; set; }
        public bool IsDeleted { get; set; }
    }
}
