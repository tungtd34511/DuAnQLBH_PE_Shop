using App.Data.Ultilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class UserDetail
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public string? Email { get; set; }
        public string? CCCD { get; set; } // căn cước công dân
        public string? Address { get; set; }
        public string? ImagePath { get; set; }
        public DateTime Created{ get; set; }
        public DateTime DoB { get; set; }
        public virtual User User { get; set; }
    }
}
