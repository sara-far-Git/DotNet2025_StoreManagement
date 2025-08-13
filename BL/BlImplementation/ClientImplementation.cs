using BlApi;
using BO;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation;

internal class ClientImplementation : IClient
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public int Create(BO.Client item)
    {
        try
        {
            return _dal.Client.Create(BO.Tools.ConvertToDo(item));
        }
        catch (DO.DalNotFound ex)
        {
            throw new BO.BlDoesExistException("the Client is exist already.", ex);
        }
    }

    public void Delete(int id)
    {
        try
        { _dal.Client.Delete(id); }

        catch { throw new Exception(""); }
    }
    public BO.Client? Read(int id)
    {
        try
        {
            return BO.Tools.ConvertToBo(_dal.Client.Read(id));
        }
        catch (DO.DalNotFound ex)
        { throw new BO.BlDoesExistException("the client was not found", ex); }
    }

    public BO.Client? Read(Func<BO.Client, bool> filter)
    {
        try
        {
            return BO.Tools.ConvertToBo(_dal.Client.Read(doSale => filter(BO.Tools.ConvertToBo(doSale))));
        }
        catch (DO.DalNotFound ex)
        { throw new BO.BlDoesNotExistException("the order not found", ex); }
    }
    public List<BO.Client?> ReadAll(Func<BO.Client, bool>? filter = null)
    {
        try
        {
            List<DO.Client> doCustomres;
            if (filter == null)
                doCustomres = _dal.Client.ReadAll();
            else
                doCustomres = _dal.Client.ReadAll(doCustomres => filter(BO.Tools.ConvertToBo(doCustomres)));
            return doCustomres.Select(x => BO.Tools.ConvertToBo(x)).ToList();
        }
        catch(Exception ex)
        { throw new Exception("Failed to delete client.", ex); }
    }
    public void Update(BO.Client item)
    {
        try
        {
            _dal.Client.Update(BO.Tools.ConvertToDo(item));
        }
        catch (DO.DalNotFound ex) { throw new BO.BlDoesNotExistException("the order not found", ex); }
    }
}