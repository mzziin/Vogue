using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class OrderEntity
    {
        public string Name { get; set; }
        public string PaymentMethod { get; set; }
        public string Quantity { get; set; }
        public string TotalPrice { get; set; }
        public string OrderStatus { get; set; }
    }
}
