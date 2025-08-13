using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    internal class SaleImplementation : Isale
    {
        public int Create(Sale item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Sale? Read(int id)
        {
            throw new NotImplementedException();
        }

        public Sale? Read(Func<Sale, bool>? filter)
        {
            throw new NotImplementedException();
        }

        public List<Sale?> ReadAll(Func<Sale, bool>? filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Sale item)
        {
            throw new NotImplementedException();
        }
    }
}
