using App.Data.Ultilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Ultilities.Catalog.Units
{
    public class GetPagingUnitRequest : PagedResultBase
    {
        public string Keyword { get; set; } = "";
        public int OrderBy { get; set; }
        public bool UnHide { get; set; } = false;
    }
}
