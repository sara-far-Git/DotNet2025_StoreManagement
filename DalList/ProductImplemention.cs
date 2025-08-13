

namespace Dal;
using DO;
using DalApi;
using System.Collections.Generic;
using Tools;
using System.Reflection;

internal class ProductImplemention : IProduct
{

    public int Create(Product item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Incoming to function with params object from type Client");

        Product product1 = DataSource.products.FirstOrDefault(product => item.id == product.id);

        if (product1 != null)
        {
            throw new DalFound("הלקוח קיים");
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "throw exception client exist");
        }

        DataSource.products.Add(item);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "out to function and add to list of client alse client");
        return item.id;
    }

    public void Delete(int id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Income to function with parans of tz from type int");
        Product? product = Read(id);
        DataSource.products.Remove(product);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "out to function and delete from list of clients client");
    }

    public Product? Read(int id)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Income to function with parans of tz from type int");
        Product product1 = DataSource.products.FirstOrDefault(product => id == product.id);

        if (product1 == null)
        {
            throw new DalNotFound("הלקוח אינו קיים");
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "throw exception client exist");
        }
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "out to function and read from list of clients client");
        return product1;
    }


    public List<Product> ReadAll(Func<Product, bool>? filter = null)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Income to function with parans of function from type deligate");
        if (filter == null)
            return DataSource.products;
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "out to function and read all the list  of clients");
        return DataSource.products.Where((c) => filter(c)).ToList();
    }
    public Product? Read(Func<Product, bool>? filter)
    {
        return DataSource.products.FirstOrDefault(filter);
    }

    public void Update(Product item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Income to function with parans of object from type Client");
        Delete(item.id);
        DataSource.products.Add(item);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "out to function and update from list of clients client");

    }
}
