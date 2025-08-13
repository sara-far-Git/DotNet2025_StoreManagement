using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class SaleInProduct
    {
        public int saleId { get; set; }
        public int count { get; set; }

        public double price { get; set; }

        public bool allClient { get; set; }
        public SaleInProduct(int saleId, int count , double price, bool allClient)
        {
            this.saleId = saleId;
            this.count = count;
            this.price = price;
            this.allClient = allClient;
        }
        public SaleInProduct()
        {
            
        }
    }
}
