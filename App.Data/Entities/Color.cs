using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class Color
    {
        public string Id { get;set; }
        public string Name { get; set; }
        public virtual List<ProductVariation> ProductVariations { get; set; }
        public bool IsDeleted { get; set; }
    }
}
