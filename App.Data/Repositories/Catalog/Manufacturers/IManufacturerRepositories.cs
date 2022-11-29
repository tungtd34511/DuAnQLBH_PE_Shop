using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Manufacturers;
using App.Data.Ultilities.Common;

namespace App.Data.Repositories.Catalog.Manufacturers
{
    public interface IManufacturerRepositories : IBaseRepositories<Manufacturer>
    {
        Task<List<ManufacturerInCreateProduct>> GetAllForCreate();
        Task<PagedResult<Manufacturer>> GetPaging(GetPagingManufactureRequest request);
        Task<string> Valiate(string name);
    }
}
