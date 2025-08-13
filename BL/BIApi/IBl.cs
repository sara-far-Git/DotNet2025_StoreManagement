using BIApi;
using BlImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface IBl
    {
        IClient client { get; }
        ISale sale {  get; }
        IOrder order { get; }
        IProduct product { get; }
    }
}
