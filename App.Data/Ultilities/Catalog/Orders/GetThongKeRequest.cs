using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Ultilities.Catalog.Orders
{
    public class GetThongKeRequest
    {
        public DateTime Started { get; set; }
        public DateTime Ended { get; set; } = DateTime.Now;

    }
}
