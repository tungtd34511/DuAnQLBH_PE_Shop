using App.Data.Ultilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Ultilities.Catalog.Products
{
    public class GetPagingShoppingRequest : PagingRequestBase
    {
        public string? Keyword { get; set; } = "";
        public bool[]? Checks { get; set; }
        public int OderBy { get; set; } = 0;
        public GetPagingShoppingRequest()
        {
            this.PageSize = 12;
        }
    }
}
