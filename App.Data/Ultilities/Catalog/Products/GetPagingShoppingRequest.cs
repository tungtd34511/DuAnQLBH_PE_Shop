﻿using App.Data.Ultilities.Common;
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
    }
}