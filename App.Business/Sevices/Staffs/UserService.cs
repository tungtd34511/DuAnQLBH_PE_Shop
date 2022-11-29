using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data.Repositories.Staffs;
using App.Data.Ultilities.ViewModels;
using App.Data.Entities;
using App.Data.Ultilities.Enums;

namespace App.Business.Sevices.Staffs
{
    public class UserService : IUserService
    {
        private IUserRepositories _iUser;
        private IUserDetailRepositories _iUserDetail;
        private List<StaffVm> _lstUserVm;
        private List<User> _lstUser;


        public UserService(IUserRepositories userRepositories, IUserDetailRepositories iUserDetail)
        {
            _iUser = userRepositories;
            _iUserDetail = iUserDetail;
        }

        public bool ExistAccount(string userName)
        {
            throw new NotImplementedException();
        }

        public List<StaffVm> ShowAllUser()
        {
            _lstUserVm = (from a in _iUser.GetAllUserFromDb()
                          join b in _iUserDetail.GetAllUserDetailFromDb() on a.Id equals b.UserId
                          select new StaffVm()
                          {
                              Role = a.Role,
                              Status = a.Status,
                              Name = b.Name,
                              PhoneNumber = b.PhoneNumber,
                              Gender = b.Gender,
                              Address = b.Address,
                              CCCD = b.CCCD,
                              Created = b.Created,
                              DoB = b.DoB
                          }).ToList();
            //_lstUser = _iUser.GetAllUserFromDb()
            //    .Select(r => new StaffVm()
            //    {
            //        Role = r.Role,
            //        Status = r.Status,
            //        Name = r.UserDetail.Name,
            //        PhoneNumber = r.UserDetail.PhoneNumber,
            //        Gender = r.UserDetail.Gender,
            //        Email = r.UserDetail.Email,
            //        CCCD = r.UserDetail.CCCD,
            //        Address = r.UserDetail.Address,
            //        Created = r.UserDetail.Created,
            //        DoB = r.UserDetail.DoB

            //    }).ToList();
            return _lstUserVm;

        }

        public User GetByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string userID)
        {
            if (userID == null)
            {
                return false;
            }
            else
            {
                _iUser.Remove(userID);
                return true;
            }
        }

        public bool Save(User entity)
        {
            // Đầu tiên phải tìm xem user này có tồn tại hay không
            var exist = _iUser.GetByUserName(entity.UserName);
            if (exist != null)
            {
                // Đến đây là user tồn tại rồi
                throw new Exception("Tài khoản đã tồn tại!");
                return false;
            }
            //Ngược lại là user này chưa được tạo
            return _iUser.Save("", entity);

        }

        public List<User> GetAllUser()
        {
            _lstUser = _iUser.GetAllUserFromDb();
            return _lstUser;
        }
    }
}
