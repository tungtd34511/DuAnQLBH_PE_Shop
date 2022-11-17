using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Customers
{
    public class ProductDetailRepositories : BaseRepositories<Customer>, ICustomerRepositories
    {
        public ProductDetailRepositories(QLBH_Context context) : base(context)
        {
        }
    }
}
