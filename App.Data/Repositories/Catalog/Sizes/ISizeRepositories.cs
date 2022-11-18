using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Sizes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Catalog.Sizes
{
    public interface ISizeRepositories : IBaseRepositories<Size>
    {
        Task<List<SizesForCreate>> GetAllForCreate();
    }
}
