using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface IClient
    {
        int Create(Client item);
        Client? Read(int id);
        List<Client?> ReadAll(Func<Client, bool>? filter = null);
        void Update(Client item);
        void Delete(int id);
        Client? Read(Func<Client, bool>? filter);
    }
}
