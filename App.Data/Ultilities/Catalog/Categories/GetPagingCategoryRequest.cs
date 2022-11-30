using App.Data.Ultilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Ultilities.Catalog.Categories
{
    public class GetPagingCategoryRequest: PagingRequestBase
    {
        public string Keyword { get; set; } = "";
        public int Orderby { get; set; } = 0;
        public bool Unhide { get; set; } = false;
    }
}
