using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Repositories.Catalog.Units;
using App.Data.Repositories.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using App.Data.Ultilities.Common;
using App.Data.Ultilities.Catalog.Users;
using App.Data.Ultilities.Enums;
using App.Data.Ultilities.ViewModels;

namespace App.Data.Repositories.Users
{
    public class UserRepositories : BaseRepositories<User>, IUserRepositories
    {
        private readonly QLBH_Context _context;
        public UserRepositories(QLBH_Context context) : base(context)
        {
            _context = context;
        }
        public async Task<User> Authencate(string acc, string pass)
        {
            var result =  Entities.Where(c=>c.Status!=Ultilities.Enums.UserStatus.InActive).FirstOrDefault(c=>c.PasswordHash==GetMD5(pass));
            return result;
        }

        public  string GetMD5(string chuoi) // mã hóa mật khâu
        {
            string str_md5 = "";
            byte[] mang = System.Text.Encoding.UTF8.GetBytes(chuoi);

            using (MD5CryptoServiceProvider my_md5 = new())
            {
                mang = my_md5.ComputeHash(mang);
            }

            foreach (byte b in mang)
            {
                str_md5 += b.ToString("X2");
            }
            return str_md5;
        }
        public async Task<PagedResult<User>> GetUserPaging(GetUserPagingRequest request )
        {
            var query = from u in Entities
                        join ud in _context.UserDetails on u.Id equals ud.UserId
                        select new { u, ud };
            if (!String.IsNullOrEmpty(request.Keyword))
            {
               query = query.Where(c=>c.u.Id.ToString()==request.Keyword || c.ud.Name.ToLower().Contains(request.Keyword.ToLower()));
            }
            if (!request.UnHide)
            {
                query = query.Where(c => c.u.Status != UserStatus.InActive);
            }
            var totalrecords = await query.CountAsync();
            var items = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new User()
                {
                    Id = x.u.Id,
                    Status = x.u.Status,
                    UserDetail = x.u.UserDetail,
                    Role = x.u.Role,
                }).ToListAsync();
            var response = new PagedResult<User>()
            {
                TotalRecords = totalrecords,
                Items = items,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            return response;
        }
        public async Task<User> GetById(Guid id)
        {
            var user = Entities.First(x => x.Id == id);
            user.UserDetail = _context.UserDetails.First(c => c.UserId == id);
            return user;
        }
    }
}
