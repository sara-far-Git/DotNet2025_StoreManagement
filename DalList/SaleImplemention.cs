namespace Dal;
using DO;
using DalApi;
using Tools;
using System.Reflection;

internal class SaleImplemention : Isale
{
    
    public int Create(Sale item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Incoming to function with params object from type Client");

        bool sale1=DataSource.sales.Any(a=>a.id_uniqe==item.id_uniqe);
        if (sale1)
        {
            throw new DalFound("המבצע קיים");
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "throw exception client exist");
        }
        else
        {
            DataSource.sales.Add(item);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "out to function and add to list of client alse client");
            return item.id_uniqe;
        }       
    }

    public void Delete(int id_uniqe)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Income to function with parans of tz from type int");
        Sale sale = Read(id_uniqe);
        DataSource.sales.Remove(sale);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "out to function and delete from list of clients client");
    }
    public Sale? Read(Func<Sale, bool>? filter)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"read sale");
        Sale sale = DataSource.sales.FirstOrDefault(x => filter(x));
        if(sale==default)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"not found sale");
            throw new DalNotFound("המבצע לא קיים");
        }
        else
            return sale;
    }

    public Sale? Read(int id_uniqe)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Income to function with parans of tz from type int");
        Sale? sale1 = DataSource.sales.FirstOrDefault(sale => id_uniqe == sale.id_uniqe);

        if (sale1 == default)
        {
            throw new DalNotFound("המבצע אינו קיים");
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "throw exception client exist");
        }
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "out to function and read from list of clients client");
        return sale1;
    }


    public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Income to function with parans of function from type deligate");
        if (filter == null)
        {
            List<Sale> sales = new List<Sale>(DataSource.sales);
            return sales;
        }
        else
        {
            var v=DataSource.sales.Where(s => filter(s));
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "out to function and read all the list  of clients");
            return v.ToList();
        }
    }
    

    public void Update(Sale item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Income to function with parans of object from type Client");
        Delete(item.id_uniqe);
        DataSource.sales.Add(item);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "out to function and update from list of clients client");

    }
}
