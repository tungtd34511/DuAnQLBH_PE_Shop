using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;

namespace App.Data.Repositories.Staffs
{
    public class UserDetailRepositories : BaseRepositories<UserDetail>, IUserDetailRepositories
    {
        private QLBH_Context _context;
        private List<UserDetail> _lstUserDetail;
        public UserDetailRepositories(QLBH_Context context) : base(context)
        {
            _context = context;
            _lstUserDetail = new List<UserDetail>();
        }

        public List<UserDetail> GetAllUserDetailFromDb()
        {
            _lstUserDetail = _context.UserDetails.ToList();
            return _lstUserDetail;
        }
    }
}
