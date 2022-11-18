﻿using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Manufacturers;

namespace App.Data.Repositories.Catalog.Manufacturers
{
    public interface IManufacturerRepositories : IBaseRepositories<Manufacturer>
    {
        Task<List<ManufacturerInCreateProduct>> GetAllForCreate();
    }
}
