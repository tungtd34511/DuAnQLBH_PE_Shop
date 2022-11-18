using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class Category
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string? Description { set; get; }
        public int? ParentId { set; get; }
        public virtual Category Parent { get; set; }
        public bool IsDeleted { set; get; } // dùng để ẩn 
        public virtual List<Category> Categories { get; set; }
        public virtual List<ProductInCategory> ProductInCategories { get; set; }
    }
}
