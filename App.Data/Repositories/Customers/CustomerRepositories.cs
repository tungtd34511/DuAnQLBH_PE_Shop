using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Colors;
using App.Data.Ultilities.Catalog.Customers;
using App.Data.Ultilities.Common;
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
        public async Task<PagedResult<Customer>> GetPaging(GetCustomerPagingRequest request)
        {
            var query = Entities.Select(c => c);
            if (!String.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(c => c.Id.ToString() == request.Keyword || c.Name.ToLower().Contains(request.Keyword.ToLower()));
            }
            var total = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize).ToListAsync();
            //4. Select 

            var pagedResult = new PagedResult<Customer>()
            {
                TotalRecords = total,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }
    }
}
