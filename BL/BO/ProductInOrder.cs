using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class ProductInOrder
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public double basicPrice { get; set; }

        public int count { get; set; }

        public List<SaleInProduct> saleInProducts { get; set; }

        public double lastPrice { get; set; }
        public ProductInOrder(int productId,string productName,double basicPrice,int count, List<SaleInProduct> saleInProducts, double lastPrice)
        {
            this.productId = productId;
            this.productName = productName;
            this.basicPrice = basicPrice;
            this.count = count;
            this.saleInProducts = saleInProducts;
            this.lastPrice = lastPrice;
        }
        public ProductInOrder()
        {
            
        }
    }
}
