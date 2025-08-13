using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }

        public double price { get; set; }

        public int? count { get; set; }
        public Enum category { get; set; }
        public List<SaleInProduct> saleInProducts { get; set; }
        public Product(int id, string name, double price, int count, Category category)
        {
            this.id = id;
            this.name = name;   
            this.price = price;
            this.count = count;
            this.category = category;
        }
        public Product()
        {
            
        }
    }
}
