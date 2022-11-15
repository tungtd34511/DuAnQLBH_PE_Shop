using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class OrderHistory
    {
        public int Id { get; set; }
        public int OderId { get; set; }
        public virtual Order Order { get; set; }
        public string EditorName { get; set; }
        public string OderName { get; set; }
        public DateTime Edited { get; set; }
        public string Details { get; set; }
    }
}
