using App.Data.Ultilities.Catalog.Users;
using App.Data.Ultilities.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class User : IdentityUser<Guid>
    {
        public Role Role { get; set; }
        public UserStatus Status { get; set; }
        public virtual UserDetail UserDetail { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
