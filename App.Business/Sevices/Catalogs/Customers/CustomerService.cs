using App.Data.Entities;
using App.Data.Repositories.Customers;
using App.Data.Ultilities.Catalog.Customers;
using App.Data.Ultilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Sevices.Catalogs.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepositories _customerRepositories;

        public CustomerService(ICustomerRepositories customerRepositories)
        {
            _customerRepositories = customerRepositories;
        }

        public async Task<bool> Add(Customer customer)
        {
            return await _customerRepositories.AddOneAsync(customer);
        }

        public async Task<bool> ChangeStatus(Customer customer)
        {
            return await _customerRepositories.UpdateOneAsync(customer);
        }

        public async Task<Customer> GetById(int id)
        {
            return await _customerRepositories.GetAsync(new object[] { id });
        }

        public async Task<PagedResult<Customer>> GetPaging(GetCustomerPagingRequest request)
        {
            return await _customerRepositories.GetPaging(request);
        }

        public async Task<bool> Update(Customer customer)
        {
            return await _customerRepositories.UpdateOneAsync(customer);
        }
    }
}
