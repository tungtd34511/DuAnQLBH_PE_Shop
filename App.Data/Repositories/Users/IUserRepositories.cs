using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Catalog.Users;
using App.Data.Ultilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Users
{
    public interface IUserRepositories : IBaseRepositories<User>
    {
        Task<User> Authencate(string acc, string pass);
        string GetMD5(string chuoi);
        Task<PagedResult<User>> GetUserPaging(GetUserPagingRequest request);
        Task<User> GetById(Guid id);
    }
}
