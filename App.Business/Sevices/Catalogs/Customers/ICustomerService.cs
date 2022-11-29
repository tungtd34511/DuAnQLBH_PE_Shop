using App.Data.Entities;
using App.Data.Ultilities.Catalog.Colors;
using App.Data.Ultilities.Catalog.Customers;
using App.Data.Ultilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Sevices.Catalogs.Customers
{
    public interface ICustomerService
    {
        Task<bool> Add(Customer customer);
        Task<bool> Update(Customer customer);
        Task<bool> ChangeStatus(Customer customer);
        Task<Customer> GetById(int id);
        Task<PagedResult<Customer>> GetPaging(GetCustomerPagingRequest request);
    }
}
