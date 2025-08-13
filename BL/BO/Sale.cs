using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Sale
    {
        public int productId { get; set; }
        public int priceSale { get; set; }

        public bool allSale { get; set; }

        public DateTime dateStart { get; set; }

        public DateTime dateEnd { get; set; }
        public double amount { get; set; }

        public Sale(int productId, int priceSale, bool allSale, DateTime dateStart, DateTime? dateEnd = null, double? amount = null)
        {
            this.productId = productId;
            this.priceSale = priceSale;
            this.allSale = allSale;
            this.dateStart = dateStart;
        }
    }
}
