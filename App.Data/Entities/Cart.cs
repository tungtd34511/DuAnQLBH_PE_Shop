using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string ShipName { set; get; }
        public string ShipAddress { set; get; }
        public string ShipEmail { set; get; }
        public string ShipPhoneNumber { set; get; }
        public string Description { set; get; }
        public virtual List<ProductInCart> ProductInCarts { get; set; }
    }
}
