using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Ultilities.Common
{
    public class PagedResult<T> : PagedResultBase
    {
        public List<T> Items { set; get; } = new();
    }
}