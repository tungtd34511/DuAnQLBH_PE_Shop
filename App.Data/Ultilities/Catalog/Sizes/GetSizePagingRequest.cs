using App.Data.Ultilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Ultilities.Catalog.Sizes
{
    public class GetSizePagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; } = "";
        public int Orderby { get; set; }
        public bool UnHide { get; set; }
    }
}
