using DO;
using DalApi;
using Tools;


namespace DalTest
{


    public class Program
    {
        private readonly static IDal s_dal = DalApi.Factory.Get;
        


        private static void Main(string[] args)
        {
            Initialization.Initialize();

            try
            {
                int select = MenuMain();
                while (select != 0)
                {
                    switch (select)
                    {
                        case 0:
                            CleanLog();
                            break;
                        case 1:
                            SelectedProducts();
                            break;
                        case 2:
                            SelectedSale();
                            break;
                        case 3:
                            SelectedClient();
                            break;
                        default:
                            Console.WriteLine("בחירה שגויה");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private static void CleanLog()
        {
            LogManager.DeleteFile();
        }
        private static int MenuMain()
        {
            Console.WriteLine("press 0 to clean to log\n" +
                              "press 1 to product\n" +
                              "press 2 to sale\n" +
                              "press 3 to client");
            int select;
            if (!int.TryParse(Console.ReadLine(), out select))
                select = -1;
            return select;
        }
        private static void SelectedProducts()
        {

            Console.WriteLine($"press 1 to create\n" +
                              "press 2 to delete\n" +
                              "press 3 to update\n" +
                              "press 4 to read\n" +
                              "press 5 to readAll");
            int select;
            if (!int.TryParse(Console.ReadLine(), out select))
                select = -1;

            switch (select)
            {
                case 0:
                    break;
                case 1:
                    {
                        CreatedProduct();
                    }
                    break;
                case 2:
                    {
                        Delete<Product>(s_dal.Product);
                    }
                    break;
                case 3:
                    {
                        UpdateProduct();
                    }
                    break;
                case 4:
                    {
                        Read<Product>(s_dal.Product);
                    }

                    break;
                case 5:
                    {
                        ReadAll<Product>(s_dal.Product);
                    }
                    break;

            }

        }
        public static void CreatedProduct()
        {
            try
            {
                Product p = InputUserProduct();
                int code = s_dal.Product.Create(p);
                p=p with { id = code };
                Console.WriteLine("successful");
                Console.WriteLine(p);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        private static Product InputUserProduct(int id = 0)
        {
            Console.WriteLine("insert name");
            string name=Console.ReadLine();
            Console.WriteLine("insert price");
            double price;
            if (!double.TryParse(Console.ReadLine(), out price))
                price = -1;
            Console.WriteLine("insert count");
            int count;
            if (!int.TryParse(Console.ReadLine(), out count))
                count = -1;
            
            Console.WriteLine("insert category");
            int num;
            if (!int.TryParse(Console.ReadLine(), out num)) num = 0;
            Category category = (Category)num;

            return new Product(id, name, price, count, category);
        }
        public static void Delete<T>(ICrud<T> crud)
        {
            try
            {
                Console.WriteLine("insert id");
                int id = int.Parse(Console.ReadLine());
                crud.Delete(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message, e);
            }
        }
        public static void UpdateProduct()
        {
            try
            {
                Console.WriteLine("הכנס קוד מוצר");
                int id = int.Parse(Console.ReadLine());
                Product p = InputUserProduct();
                p = p with { id = id };
                s_dal.Product.Update(p);
                Console.WriteLine("the update successful");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message, e);
            }
        }
        public static void UpdateClient()
        {
            try
            {
                Console.WriteLine("הכנס מספר זהות");
                int tz = int.Parse(Console.ReadLine());
                Client c = InputUserClient();
                c = c with { tz = tz };
                s_dal.Client.Update(c);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message, e);
            }
        }
        public static void UpdateSale()
        {
            try
            {
                Console.WriteLine("הכנס קוד מוצר");
                int id = int.Parse(Console.ReadLine());
                Sale s = InputUserSale();
                s = s with { productId = id };
                s_dal.Sale.Update(s);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message, e);
            }
        }

        public static void Read<T>(ICrud<T> crud)
        {
            try
            {
                Console.WriteLine("הכנס מספר מזהה");
                int id = int.Parse(Console.ReadLine());
                crud.Read(id);
                Console.WriteLine("the read successful");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message, e);
            }
        }
        public static void ReadAll<T>(ICrud<T> crud)
        {
            Console.WriteLine("the readAll successful");
            crud.ReadAll();
        }
        private static void SelectedClient()
        {
            Console.WriteLine($"press 1 to create\n" +
                                  "press 2 to delete\n" +
                                  "press 3 to update\n" +
                                  "press 4 to read\n" +
                                  "press 5 to readAll");
            int select = int.Parse(Console.ReadLine());
            if (!int.TryParse(Console.ReadLine(), out select))
                select = -1;

            switch (select)
            {
                case 0:
                    break;
                case 1:
                    {
                        CreateClient();
                    }
                    break;
                case 2:
                    {
                        Delete<Client>(s_dal.Client);
                    }
                    break;
                case 3:
                    {
                        UpdateClient();
                    }
                    break;
                case 4:
                    {
                        Read<Client>(s_dal.Client);
                    }

                    break;
                case 5:
                    {
                        ReadAll<Client>(s_dal.Client);
                    }
                    break;

            }
        }
        public static void CreateClient()
        {
            try
            {
                Client c = InputUserClient();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message, e);
            }
        }
        private static Client InputUserClient()
        {
            Console.WriteLine("הכנס תעודת זהות");
            int tz = int.Parse(Console.ReadLine());
            Console.WriteLine("הכנס שם פרטי ומשפחה");
            string name = Console.ReadLine();
            Console.WriteLine("הכנס כתובת");
            string adress = Console.ReadLine();
            Console.WriteLine("הכנס טלפון");
            int phone = int.Parse(Console.ReadLine());
            return new Client(tz, name, adress, phone);
        }
        public static void SelectedSale()
        {
            Console.WriteLine($"press 1 to create\n" +
                                  "press 2 to delete\n" +
                                  "press 3 to update\n" +
                                  "press 4 to read\n" +
                                  "press 5 to readAll");
            int select;
            if (!int.TryParse(Console.ReadLine(), out select))
                select = -1;

            switch (select)
            {
                case 0:
                    break;
                case 1:
                    {
                        CreateSale();
                    }
                    break;
                case 2:
                    {
                        Delete<Sale>(s_dal.Sale);
                    }
                    break;
                case 3:
                    {
                        UpdateSale();
                    }
                    break;
                case 4:
                    {
                        Read<Sale>(s_dal.Sale);
                    }

                    break;
                case 5:
                    {
                        ReadAll<Sale>(s_dal.Sale);
                    }
                    break;

            }
        }
        private static void CreateSale()
        {
            try
            {
                Sale s = InputUserSale();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static Sale InputUserSale(int productId = 0)
        {
            Console.WriteLine("הכנס מחיר במבצע");
            int priceSale = int.Parse(Console.ReadLine());
            Console.WriteLine("הכנס כמות במבצע");
            bool allSale = bool.Parse(Console.ReadLine());
            Console.WriteLine("הכנס תאריך פתיחה");
            DateTime dateStart = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("הכנס תאריך סיום");
            DateTime dateEnd = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("הכנס כמות");
            Double amount = int.Parse(Console.ReadLine());
            int id_uniqe=int.Parse(Console.ReadLine());
            return new Sale(productId,id_uniqe, priceSale, allSale, dateStart, dateEnd);
        }





    }
}

