using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Ultilities.Common
{
    public class PagingRequestBase
    {
        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 20;
    }
}