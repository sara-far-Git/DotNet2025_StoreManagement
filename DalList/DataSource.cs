
namespace Dal;
using DO;

public static class DataSource
{
    static internal List<Client?> clients = new List<Client?>();
    static internal List<Product?> products = new List<Product?>();
    static internal List<Sale?> sales = new List<Sale?>();

    internal static class Config
    {
        internal const int ProductStartNum = 100;
        internal const int SaleStartNum = 200;


        private static int productStatic = ProductStartNum;
        private static int saleStatic = SaleStartNum;

        public static int GetStaticproduct
        {
            get
            {
                int temp = productStatic;
                productStatic++;
                return temp;
            }

        }

        public static int GetStaticSale
        {
            get 
            { 
                return saleStatic; 
            }
            
        }
    }

}
