using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Repositories.Catalog.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Users
{
    public class UserDetailRepositories : BaseRepositories<UserDetail>, IUserDetailRepositories
    {
        public UserDetailRepositories(QLBH_Context context) : base(context)
        {
        }
    }
}
