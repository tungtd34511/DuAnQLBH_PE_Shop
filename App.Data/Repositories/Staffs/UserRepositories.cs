using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Ultilities.Password;

namespace App.Data.Repositories.Staffs
{
    public class UserRepositories : BaseRepositories<User>, IUserRepositories
    {
        private QLBH_Context _context;
        private List<User> _lstUser;
        public UserRepositories(QLBH_Context context) : base(context)
        {
            _context = context;
            _lstUser = new List<User>();
        }
        public bool ExistAccount(string userName)
        {
            if (ExistAccount(userName))
                return false;
            return true;

        }

        public List<User> GetAllUserFromDb()
        {

            _lstUser = _context.Users.ToList();
            return _lstUser;

        }

        public User GetByUserName(string userName)
        {
            if (userName == String.Empty)
            {
                return null;
            }
            else
            {
                return _context.Users.FirstOrDefault(c => c.UserName == userName);
            }
        }

        public bool Remove(string userID)
        {
            try
            {
                _context.Remove(userID);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi cụ thể: {0}", e.Message);
                return false;
            }
        }

        public bool Save(string userID, User entity)
        {
            try
            {
                if (string.IsNullOrEmpty(userID))
                {
                    entity.Id = Guid.NewGuid();
                    entity.PasswordHash = CreatePassword.CreateRandomPassword(8);
                    _context.Add(entity);
                }
                else
                {
                    _context.Update(entity);
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi cụ thể: {0}", ex.Message);

                return false;
            }
        }
    }
}
