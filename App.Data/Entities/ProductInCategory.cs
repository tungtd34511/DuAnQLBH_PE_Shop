using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class ProductInCategory
    {
        public int CategoryId { set; get; }
        public int ProductId { set; get; }
        public virtual Category Category { get; set; }
        public virtual Product Product { get; set; }
    }
}
