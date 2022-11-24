using App.Data.Entities;
using App.Data.Repositories.Catalog.Manufacturers;
using App.Data.Ultilities.Catalog.Manufacturers;
using App.Data.Ultilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Sevices.Catalogs.Manufactures
{
    public class ManufactureService : IManufactureServices
    {
        private readonly IManufacturerRepositories _manufacturerRepositories;

        public ManufactureService(IManufacturerRepositories manufacturerRepositories)
        {
            _manufacturerRepositories = manufacturerRepositories;
        }

        public async Task<bool> Add(Manufacturer manufacturer)
        {
            return await _manufacturerRepositories.AddOneAsync(manufacturer);
        }

        public async Task<bool> ChangeStatus(Manufacturer manufacturer)
        {
            return await _manufacturerRepositories.UpdateOneAsync(manufacturer);
        }

        public async Task<Manufacturer> GetManufacturerById(int id)
        {
            return await _manufacturerRepositories.GetAsync(new object[] { id });
        }

        public async Task<bool> Update(Manufacturer manufacturer)
        {
            return await _manufacturerRepositories.UpdateOneAsync(manufacturer);
        }
        public  async Task<PagedResult<Manufacturer>> GetPaging(GetPagingManufactureRequest request)
        {
            return await _manufacturerRepositories.GetPaging(request);
        }
    }
}
