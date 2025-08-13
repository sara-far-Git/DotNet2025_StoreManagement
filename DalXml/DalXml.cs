using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    internal sealed class DalXml : IDal
    {
        public IClient Client => new ClientImplementation();

        public IProduct Product => new ProductImplementation();

        public Isale Sale => new SaleImplementation();

        private readonly DalXml instance=new DalXml();
        public static readonly DalXml Instance;

        public DalXml Innstance
        {
            get { return instance; }
        }

        
        private DalXml()
        {
            
        }
    }
}
