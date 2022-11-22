using App.Data.Ultilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Ultilities.ViewModels
{
    public class ProductInShoppingVm
    {
        public int Id { get; set; }
        public decimal Price { set; get; }
        public string Name { set; get; }
        public string? ThumbailImage { get; set; }
    }
}
