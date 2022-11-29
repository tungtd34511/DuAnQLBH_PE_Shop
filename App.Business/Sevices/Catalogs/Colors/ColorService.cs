using App.Data.Entities;
using App.Data.Repositories.Catalog.Colors;
using App.Data.Ultilities.Catalog.Colors;
using App.Data.Ultilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Sevices.Catalogs.Colors
{
    public class ColorService : IColorService
    {
        private readonly IColorRepositories _colorRepositories;

        public ColorService(IColorRepositories colorRepositories)
        {
            _colorRepositories = colorRepositories;
        }

        public async Task<bool> Add(Color color)
        {
            return await _colorRepositories.AddOneAsync(color);
        }

        public async Task<bool> ChangeStatus(Color color)
        {
            return await _colorRepositories.UpdateOneAsync(color);
        }

        public Task<Color> GetById(string id)
        {
            return _colorRepositories.GetAsync(new object[] { id });
        }

        public async Task<PagedResult<Color>> GetPaging(GetColorPagingRequest request)
        {
            return await _colorRepositories.GetPaging(request);
        }

        public async Task<bool> Update(Color color)
        {
            return await _colorRepositories.UpdateOneAsync(color);
        }
        public async Task<string> Validate(string id, string Name)
        {
            return await _colorRepositories.Validate(id, Name);
        }
    }
}
