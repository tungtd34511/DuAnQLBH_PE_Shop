using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Views.Services.Base
{
    public interface IBaseService
    {
         Task<string> hello(string name);
    }
}
