using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Customers
{
    public class CustomerRepositories : BaseRepositories<Customer>, ICustomerRepositories
    {
        public CustomerRepositories(QLBH_Context context) : base(context)
        {
        }

        public async Task<IEnumerable<Customer>> GetByPhoneNumber(string phonenumber)
        {
            return await Entities.Where(c=>c.PhoneNumber.Contains(phonenumber)).Take(10).ToListAsync();
        }
    }
}
