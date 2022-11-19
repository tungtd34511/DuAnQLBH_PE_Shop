using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Ultilities.Catalog.Products
{
    public class DeleteImageRequest
    {
        public int ProductId { get; set; }
        public string[] Paths { get; set; }
    }
}
