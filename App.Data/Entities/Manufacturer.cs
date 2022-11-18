using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class Manufacturer // Nhà sản xuất
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Details { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; } // Dòng này dùng để ẩn thay cho việc xóa để không hiện khi thêm mới sản phẩm
        public virtual List<ProductDetail> ProductDetails { get; set; }
    }
}
