using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using App.Data.Repositories.Catalog.Units;
using App.Data.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Users
{
    public class UserRepositories : BaseRepositories<User>, IUserRepositories
    {
        public UserRepositories(QLBH_Context context) : base(context)
        {
        }
    }
}
