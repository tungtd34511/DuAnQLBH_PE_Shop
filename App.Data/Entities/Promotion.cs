using App.Data.Ultilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class Promotion
    {
        public int Id { set; get; }
        public DateTime FromDate { set; get; }
        public DateTime ToDate { set; get; }
        public bool ApplyForAll { set; get; }
        public int DiscountPercent { set; get; }
        public decimal DiscountAmount { set; get; }
        public string ProductIds { set; get; } // aplly theo id sản phẩm
        public string ProductCategoryIds { set; get; } // apply theo danh mục
        public PromotionStatus Status { set; get; }
        public string Title { set; get; }
        public string Name { set; get; }
    }
}
