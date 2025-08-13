using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Linq;


namespace Dal
{
    internal class ClientImplementation : IClient
    {
        static Client client;
        const string filePath = @"../xml/clients.xml";

        const string TZ = "tz";
        const string NAME = "name";
        const string ADDRESS = "address";
        const string PHONE = "phone";
        
        public int Create(Client item)
        {
            XElement root;
            // אם הקובץ קיים — טוענים אותו
            if (File.Exists(filePath))
                root = XElement.Load(filePath);
            else
                // אם הקובץ לא קיים — יוצרים אלמנט שורש חדש
                root = new XElement("Client");
            // יוצרים אלמנט חדש עבור הלקוח
            XElement xElementClient = new XElement("Client",
                new XElement(TZ,item.tz),
                new XElement(NAME,item.name),
                new XElement(ADDRESS,item.address),
                new XElement(PHONE,item.phone)
                );
            root.Add(xElementClient);
            root.Save(filePath);
            return item.tz;
        }

        public void Delete(int id)
        {
            if (!File.Exists(filePath))
                throw new Exception("הקובץ לא קיים");
            XElement root = XElement.Load(filePath);
            var client = root.Elements("Client").FirstOrDefault(e => (int)e.Element("Id") == id);
            if (client == null)
                throw new Exception("הלקוח לא קיים");
            client.Remove();
            root.Save(filePath);
        }

        public Client? Read(int tz)
        {
            if (!File.Exists(filePath))
                throw new Exception("הקובץ לא קיים");
            XElement root = XElement.Load(filePath);
            var client = root.Elements("Client").FirstOrDefault(e => (int)e.Element("Id") == tz);
            if (client == null)
                throw new Exception("הלקוח לא קיים");
            return new Client
            {
                tz = (int)client.Element(TZ),
                name = (string)client.Element(NAME),
                address = (string)client.Element(ADDRESS),
                phone = (int)client.Element(PHONE)
            };
        }

        public Client? Read(Func<Client, bool>? filter)
        {
            if (!File.Exists(filePath))
                throw new Exception("הקובץ לא קיים");

            XElement root = XElement.Load(filePath);

            var clients = root.Elements("Client")
                              .Select(e => new Client
                              {
                                  tz = (int)e.Element(TZ),
                                  name = (string)e.Element(NAME),
                                  address = (string)e.Element(ADDRESS),
                                  phone = (int)e.Element(PHONE)
                              })
                              .ToList();
            if(filter!=null)
                clients=clients.Where(filter).ToList();
            return clients.FirstOrDefault();
        }

        public List<Client?> ReadAll(Func<Client, bool>? filter = null)
        {
            List<Client> clients = new List<Client>();
            if (!File.Exists(filePath))
                return clients;
            XElement root = XElement.Load(filePath);
            clients = root.Elements("Client").Select(e => new Client
            {
                tz = (int)e.Element(TZ),
                name = (string)e.Element(NAME),
                address = (string)e.Element(ADDRESS),
                phone = (int)e.Element(PHONE)
            })
            .ToList();
            return clients;
        }

        public void Update(Client item)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("הקובץ לא קיים");

            XElement root = XElement.Load(filePath);

            var client = root.Elements("client")
                                      .FirstOrDefault(e => (int)e.Element("Id") == item.tz);

            if (client == null)
                throw new Exception("לקוח לא נמצא");
            client.Element(NAME).Value = item.name;
            root.Save(filePath);    
        }
    }
}
