using App.Data.Entities;
using App.Data.Repositories.Catalog.Manufacturers;
using App.Data.Repositories.Catalog.Units;
using App.Data.Ultilities.Catalog.Units;
using App.Data.Ultilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Sevices.Catalogs.Units
{
    public class UnitService : IUnitServices
    {
        private readonly IUnitRepositories _unitRepositories;

        public UnitService(IUnitRepositories unitRepositories)
        {
            _unitRepositories = unitRepositories;
        }

        public async Task<bool> Add(Unit unit)
        {
            return await _unitRepositories.AddOneAsync(unit);
        }

        public async Task<bool> ChangeStatus(Unit unit)
        {
            return await _unitRepositories.UpdateOneAsync(unit);
        }

        public async Task<Unit> GetById(int id)
        {
            return await _unitRepositories.GetAsync(new object[] { id });
        }

        public async Task<PagedResult<Unit>> GetPaging(GetPagingUnitRequest request)
        {
            return await _unitRepositories.GetPaging(request);
        }

        public async Task<bool> Update(Unit unit)
        {
            return await _unitRepositories.UpdateOneAsync(unit);
        }
    }
}
