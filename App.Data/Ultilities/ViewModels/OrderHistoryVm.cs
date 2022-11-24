using App.Data.Entities;
using App.Data.Ultilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Ultilities.ViewModels
{
    public class OrderHistoryVm
    {
        public OrderStatus Status { get; set; }
        public string EditorName { get; set; }
        public string OderName { get; set; }
        public DateTime Edited { get; set; }
        public string Details { get; set; }
    }
}
