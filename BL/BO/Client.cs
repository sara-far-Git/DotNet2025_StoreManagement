using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Client
    {
        public int tz { get; set; }
        public string name { get; set; }

        public string adress { get; set; }

        public int phone { get; set; }

        public Client(int tz, string name, string adress, int phone)
        {
            this.tz = tz;
            this.name = name;
            this.adress = adress;
            this.phone = phone;
        }
        public Client()
        {
            
        }
    }
}
