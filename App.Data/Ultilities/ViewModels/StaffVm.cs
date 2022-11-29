using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data.Entities;
using App.Data.Ultilities.Enums;

namespace App.Data.Ultilities.ViewModels
{
    public class StaffVm
    {
        public Role Role { get; set; }
        public UserStatus Status { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string CCCD { get; set; }
        public string Address { get; set; }
        public DateTime Created { get; set; }
        public DateTime DoB { get; set; }
    }
}
