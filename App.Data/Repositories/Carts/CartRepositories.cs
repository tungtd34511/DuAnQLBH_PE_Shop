using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories.Carts
{
    public class CartRepositories : BaseRepositories<Cart>, ICartRepositories
    {
        private readonly QLBH_Context _context;
        public CartRepositories(QLBH_Context context) : base(context)
        {
            _context = context;
        }

        public async Task<string> Hello(string text)
        {
            return text;
        }
    }
}
