using DO;
using DalApi;
using System;


namespace DalTest;


public static class Initialization
{
    private static IDal s_dal;

    private static void creatProduct()
    {
        s_dal.Product.Create(new Product(763895, "sara", 150, 8, Category.נוף));
        s_dal.Product.Create(new Product(656535, "tamar", 200, 6, Category.נוף));
        s_dal.Product.Create(new Product(098675, "lea", 350, 5, Category.נוף));
        s_dal.Product.Create(new Product(764542, "sarit", 100, 25, Category.נוף));
        s_dal.Product.Create(new Product(259064, "noa", 175, 10, Category.נוף));
        s_dal.Product.Create(new Product(970534, "rivka", 950, 3, Category.נוף));
        s_dal.Product.Create(new Product(753453, "shoshana", 140, 9, Category.נוף));

    }

    public static void creatClient()
    {
        //s_dal.client.Create();
        s_dal.Client.Create(new Client());
     }

    public static void creatsale()
    {
        //s_dal.Sale.Create(new Product());
    }

    public static void Initialize()
    {
        s_dal = DalApi.Factory.Get;
        creatProduct();
        creatClient();
        creatsale();

    }

}


