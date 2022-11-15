using App.Data.Ultilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class ProductDetail
    {
        public int ProductId { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public Gender Gender { set; get; }
        public int UnitId { get; set; }
        public virtual Unit Unit { set; get; } // Đơn vị
        public virtual Product Product { get; set; }
        public int ManufacturerId { set; get; } 
        public virtual Manufacturer Manufacturer { get; set; }
    }
}
