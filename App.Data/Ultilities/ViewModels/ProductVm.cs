using App.Data.Entities;
using App.Data.Ultilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Ultilities.ViewModels
{
    public class ProductVm
    {
        public int Id { get; set; }
        public decimal Price { set; get; } 
        public decimal OriginalPrice { set; get; }
        public DateTime DateCreated { set; get; }
        public ProductStatus Status { get; set; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public Gender Gender { set; get; }
        public int UnitId { get; set; }
        public string UnitName { set; get; } // Đơn vị
        public int ManufacturerId { set; get; }
        public string ManufacturerName { get; set; }
        public List<int> Categories { get; set; }
        public List<string> Images { get; set; }
    }
}
