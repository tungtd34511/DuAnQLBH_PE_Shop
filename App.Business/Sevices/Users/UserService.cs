using App.Data.Entities;
using App.Data.Repositories.Users;
using App.Data.Ultilities.Catalog.Users;
using App.Data.Ultilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Sevices.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepositories _userRepositories;
        private readonly IUserDetailRepositories _userDetailRepositories;
        public UserService(IUserRepositories userRepositories, IUserDetailRepositories userDetailRepositories)
        {
            _userRepositories = userRepositories;
            _userDetailRepositories = userDetailRepositories;
        }
        public async Task<User> Authenticate(string acc, string password)
        {
            return await _userRepositories.Authencate(acc, password);
        }
        public async Task CreateAdmin()
        {
            //acc: Taduytung99 pass: Taduytung123
            await _userRepositories.AddOneAsync(new User() { Id = Guid.NewGuid(), Status = Data.Ultilities.Enums.UserStatus.FirstLogin, PasswordHash = _userRepositories.GetMD5("Taduytung123"), UserName = "Taduytung99" });
        }
        public async Task<UserDetail> GetDetailById(Guid id)
        {
            return await _userDetailRepositories.GetAsync(new object[] { id });
        }
        public async Task<bool> UpdateImage(UserDetail detail)
        {
                return await _userDetailRepositories.UpdateOneAsync(detail);  
        }
        public async Task<bool> UpdateUser(UserDetail user)
        {
            return await _userDetailRepositories.UpdateOneAsync(user);
        }
        public async Task<bool> UpdatePassword(User user) 
        {
            user.PasswordHash = _userRepositories.GetMD5(user.PasswordHash);
            return await _userRepositories.UpdateOneAsync(user);
        }
        public async Task<PagedResult<User>> GetUserPaging(GetUserPagingRequest request)
        {
            return await _userRepositories.GetUserPaging(request);
        }
        public async Task<User> GetById(Guid id)
        {
            return await _userRepositories.GetById(id);
        }
        public async Task<bool> ChaneStatus(User user)
        {
            return await _userRepositories.UpdateOneAsync(user);
        }
        public async Task<bool> AddUser(User user)
        {
            user.PasswordHash = _userRepositories.GetMD5(user.PasswordHash);
            return await _userRepositories.AddOneAsync(user);
        }
    }
}
