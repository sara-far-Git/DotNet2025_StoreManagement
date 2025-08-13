using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using BlImplementation;
using BlApi;

namespace BlApi
{
    public static class Factory
    {
        public static IBl Get { get => new Bl();}

    }

    
}
