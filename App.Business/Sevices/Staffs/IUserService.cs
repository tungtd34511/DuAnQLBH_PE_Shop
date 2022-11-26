using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data.Entities;
using App.Data.Ultilities.ViewModels;

namespace App.Business.Sevices.Staffs
{
    public interface IUserService
    {
        bool Save(User entity);
        bool Remove(string userID);
        User GetByUserName(string userName);
        List<StaffVm> ShowAllUser();
        List<User> GetAllUser();
        bool ExistAccount(string userName);
    }
}
