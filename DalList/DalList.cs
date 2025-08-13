using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal;

internal sealed class DalList : IDal
{
    public static DalList Instance { get; private set; }
    public IClient Client=>new ClientImplemention();
    public Isale Sale=>new SaleImplemention();
    public IProduct Product=>new ProductImplemention();
    private DalList()
    {
        Instance=new DalList();
    }

}
