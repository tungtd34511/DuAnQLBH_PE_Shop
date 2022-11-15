using App.Data.Entities;
using App.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Carts
{
    public interface ICartRepositories : IBaseRepositories<Cart>
    {
        Task<string> Hello(string text);
    }
}
