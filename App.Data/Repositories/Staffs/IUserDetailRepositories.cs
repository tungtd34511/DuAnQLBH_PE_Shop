using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data.Entities;
using App.Data.Repositories.Base;

namespace App.Data.Repositories.Staffs
{
    public interface IUserDetailRepositories : IBaseRepositories<UserDetail>
    {
        List<UserDetail> GetAllUserDetailFromDb();

    }
}
