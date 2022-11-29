using App.Data.Entities;
using App.Data.Repositories.Catalog.Sizes;
using App.Data.Ultilities.Catalog.Sizes;
using App.Data.Ultilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Sevices.Catalogs.Sizes
{
    public class SizeService : ISizeService
    {
        private readonly ISizeRepositories _sizeRepositories;

        public SizeService(ISizeRepositories sizeRepositories)
        {
            _sizeRepositories = sizeRepositories;
        }

        public async Task<bool> Add(Size size)
        {
            return await _sizeRepositories.AddOneAsync(size);
        }

        public async Task<bool> ChangeStatus(Size size)
        {
           return await _sizeRepositories.UpdateOneAsync(size);
        }

        public Task<Size> GetById(string id)
        {
            return _sizeRepositories.GetAsync(new object[] { id });
        }

        public async Task<PagedResult<Size>> GetPaging(GetSizePagingRequest request)
        {
            return await _sizeRepositories.GetPaging(request);
        }

        public async Task<bool> Update(Size size)
        {
            return await _sizeRepositories.UpdateOneAsync(size);
        }

        public async Task<string> Validate(string id, string name)
        {
            return await _sizeRepositories.Validate(id, name);
        }
    }
}
