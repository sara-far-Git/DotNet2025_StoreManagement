using DalApi;
using DalTest;
using DO;
using Tools;
using BO;

namespace BLTest
{
    internal class Program
    {
        static readonly BlApi.IBl s_bl = BlApi.Factory.Get;
        static void Main(string[] args)
        {
            Console.WriteLine("to initialization data");
            bool agree = bool.Parse(Console.ReadLine());
            if(agree) 
                Initialization.Initialize();
            bool flug=false;
            while(true)
            {
                Console.WriteLine("Enter to clientId or 0 to end");
                int clientId=int.Parse(Console.ReadLine());
                Console.WriteLine("Enter to exist client");
                bool existClient=bool.Parse(Console.ReadLine());
                Console.WriteLine("Enter to products");
                Order order=new Order(existClient, new List<ProductInOrder>(),0);
                bool flug1=false;
                while(!flug)
                {
                    Console.WriteLine("Enter to productId or 0 to end");
                    int productID=int.Parse(Console.ReadLine());
                    if (productID == 0)
                        flug = true;
                    Console.WriteLine("Enter quantity");
                    int quantity=int.Parse(Console.ReadLine());
                    List<SaleInProduct> sales = s_bl.order.AddProductToOrder(order, productID, quantity);
                }
                s_bl.order.DoOrder(order);
                order.ToString();
                s_bl.order.CalcTotalPrice(order);
                Console.WriteLine($"the total price{order.lastPrice}");
                Console.WriteLine("Enter o to finish the order");
            }

        }
    }
    
}

