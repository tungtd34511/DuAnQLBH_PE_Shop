using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Customers;
using App.Data.Ultilities.Common;
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
        Task<PagedResult<Customer>> GetPaging(GetCustomerPagingRequest request);
        Task<string> Validate(string phonenumber);
    }
}
