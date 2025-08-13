﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;

namespace BlImplementation
{
    internal class Bl:IBl
    {
        public IClient client => new ClientImplementation();
        public ISale Sale => new SaleImplementation();
        public IOrder Order => new OrderImplementation();
        public IProduct Product => new ProductImplementation();
    }
}
