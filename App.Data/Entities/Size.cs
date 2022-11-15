using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class Size
    {
        public string Id { get; set; } //Id sẽ là mã size
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual List<ProductVariation> ProductVariations { get; set; }
    }
}
