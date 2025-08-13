
using DO;
using DalApi;
using System.Data.Common;
using Tools;
using System.Reflection;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

namespace Dal;

internal class ClientImplemention : IClient
{
    
    public int Create(Client item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName,MethodBase.GetCurrentMethod().Name,"Incoming to function with params object from type Client");

        Client client1 = DataSource.clients.FirstOrDefault(client => item.tz == client.tz);

        if (client1 != null)
        {
            throw new DalFound("הלקוח קיים");
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "throw exception client exist");
        }

        DataSource.clients.Add(item);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "out to function and add to list of client alse client");
        return item.tz;
    }

    public void Delete(int tz)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Income to function with parans of tz from type int");
        Client? client = Read(tz);
        DataSource.clients.Remove(client);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "out to function and delete from list of clients client");
    }

    public Client? Read(int tz)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Income to function with parans of tz from type int");
        Client client1 = DataSource.clients.FirstOrDefault(client => tz == client.tz);

        if (client1 == null)
        {
            throw new DalNotFound("הלקוח אינו קיים");
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "throw exception client exist");
        }
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "out to function and read from list of clients client");
        return client1;
    }


    public List<Client> ReadAll(Func<Client,bool>? filter=null)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Income to function with parans of function from type deligate");
        if (filter == null)
            return DataSource.clients;
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "out to function and read all the list  of clients");
        return DataSource.clients.Where((c)=>filter(c)).ToList();
    }
    public Client? Read(Func<Client, bool>? filter)
    {
         return DataSource.clients.FirstOrDefault(filter);
    }

    public void Update(Client item)
    {
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Income to function with parans of object from type Client");
        Delete(item.tz);
        DataSource.clients.Add(item);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "out to function and update from list of clients client");

    }
}
