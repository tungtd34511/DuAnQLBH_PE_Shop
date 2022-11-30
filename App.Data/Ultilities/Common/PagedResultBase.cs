using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Ultilities.Common
{
    public class PagedResultBase
    {
        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 20;

        public int TotalRecords { get; set; } = 0;

        public int PageCount
        {
            get
            {
                var pageCount = (double)TotalRecords / PageSize;
                return (int)Math.Ceiling(pageCount);
            }
        }
    }
}