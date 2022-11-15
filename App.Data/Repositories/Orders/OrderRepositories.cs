using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Orders
{
    public class OrderRepositories : BaseRepositories<Order>,IOrderRepositories
    {
        public OrderRepositories(QLBH_Context context) : base(context)
        {
        }
    }
}
