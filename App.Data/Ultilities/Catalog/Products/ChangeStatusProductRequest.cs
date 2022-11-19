using App.Data.Ultilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Ultilities.Catalog.Products
{
    public class ChangeStatusProductRequest
    {
        public int Id { get; set; }
        public ProductStatus Status { get; set; }
    }
}
