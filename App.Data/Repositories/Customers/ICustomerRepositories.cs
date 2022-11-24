﻿using App.Data.Entities;
using App.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Customers
{
    public interface ICustomerRepositories : IBaseRepositories<Customer>
    {
        Task<IEnumerable<Customer>> GetByPhoneNumber(string phonenumber);
    }
}
