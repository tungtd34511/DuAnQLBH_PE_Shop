using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data.Entities;
using App.Data.Repositories.Base;

namespace App.Data.Repositories.Staffs
{
        public interface IUserRepositories : IBaseRepositories<User>
        {
            bool Save(string userID, User entity);
            bool Remove(string userID);
            User GetByUserName(string userName);
            List<User> GetAllUserFromDb();
            bool ExistAccount(string userName);
        }
    
}
