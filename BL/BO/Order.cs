using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Order
    {
        public bool pariority { get; set; }
        public List<ProductInOrder> productInOrders { get; set; }
        public double lastPrice { get; set; }

        public Order(bool pariority, List<ProductInOrder> productInOrders, double lastPrice)
        {
            this.pariority = pariority;
            this.productInOrders =  new List<ProductInOrder>();
            this.lastPrice = lastPrice;
        }
    }
}
