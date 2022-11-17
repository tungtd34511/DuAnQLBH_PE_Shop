using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Views.Services.Base
{
    public class BaseService : IBaseService
    {
        public async Task<string> hello(string name)
        {
            return  name;
        }
    }
}
