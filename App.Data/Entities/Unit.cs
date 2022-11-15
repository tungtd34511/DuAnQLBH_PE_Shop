using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class Unit //Đơn vị
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;// ẩn không dùng đơn vị
        public virtual List<ProductDetail> ProductDetails { get; set; }

    }
}
