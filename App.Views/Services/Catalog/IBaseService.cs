using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Views.Services.Catalog
{
    public interface IBaseService
    {
         Task<string> hello(string name);
    }
}
