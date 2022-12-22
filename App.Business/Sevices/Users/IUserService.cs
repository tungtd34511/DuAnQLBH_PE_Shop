using App.Data.Entities;
using App.Data.Ultilities.Catalog.Users;
using App.Data.Ultilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Sevices.Users
{
    public interface IUserService
    {
        Task<User> Authenticate(string acc, string password);
        Task CreateAdmin();
        Task<UserDetail> GetDetailById(Guid id);
        Task<bool> UpdateImage(UserDetail detail);
        Task<bool> UpdateUser(UserDetail user);
        Task<bool> UpdatePassword(User user);
        Task<PagedResult<User>> GetUserPaging(GetUserPagingRequest request);
        Task<User> GetById(Guid id);
        Task<bool> ChaneStatus(User user);
        Task<bool> AddUser(User user);
        Task<string> GetMD5(string pass);
    }
}
