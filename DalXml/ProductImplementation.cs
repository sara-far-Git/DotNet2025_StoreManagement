using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Dal
{
    internal class ProductImplementation : IProduct
    {
        static string filePath = @"../xml/products.xml"; // נתיב הקובץ
        public int Create(Product item)
        {
            List<Product> products = new List<Product>();
            // אם הקובץ כבר קיים - נטען את התוכן הקיים
            if (File.Exists(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    products = serializer.Deserialize(fs) as List<Product>;
                }
            }

            // נוסיף את הלקוח החדש לרשימה
            products.Add(item);

            // נשמור את כל הרשימה בחזרה לקובץ
            XmlSerializer serializer2 = new XmlSerializer(typeof(List<Product>));
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer2.Serialize(fs, products);
            }
            return item.id;
        }
        

        public void Delete(int id)
        {
            List<Product> products = ReadAll();
            var product=products.FirstOrDefault(p=>p.id==id);
            if (product == null)
                throw new Exception("המוצר לא נמצא");
            products.Remove(product);
            XmlSerializer xmlSerializer=new XmlSerializer(typeof(List<Product>));
            using(StreamWriter sw = new StreamWriter(filePath))
            {
                xmlSerializer.Serialize(sw, products);
            }

        }

        public Product? Read(int id)
        {
            List<Product> products = ReadAll();
            return products.FirstOrDefault(c => c.id == id);
        }

        public Product? Read(Func<Product, bool>? filter)
        {
            if (!File.Exists(filePath))
                return null; // אם הקובץ לא קיים, מחזירים null
            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
            using (StreamReader reader = new StreamReader(filePath))
            {
                List<Product> products = (List<Product>)serializer.Deserialize(reader);
                // אם יש פילטר, מחפשים את המוצר שמתאים לפילטר
                return products.FirstOrDefault(filter); // מחזירים את המוצר הראשון שמתאים לפילטר או null אם לא נמצא
            }
        }
        public List<Product?> ReadAll(Func<Product, bool>? filter = null)
        {
            if (!File.Exists(filePath))
                return new List<Product>(); // אם אין קובץ, מחזירים רשימה ריקה
            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
            // טוענים את הנתונים מהקובץ
            using (StreamReader reader = new StreamReader(filePath))
            {
                List<Product?> products = (List<Product>)serializer.Deserialize(reader);
                if (filter != null)
                {
                    products = products.Where(filter).ToList();
                }
                return products;
            }
        }

        public void Update(Product item)
        {
            List<Product> products = ReadAll(); 
            var product = products.FirstOrDefault(c => c.id == item.id); 

            if (product == null)
                throw new Exception("הלקוח לא נמצא");
            
            product.id = item.id;
            product.address = item.address;
            client.phone = item.phone;

            // סריאליזציה של הרשימה חזרה ל-XML
            XmlSerializer serializer = new XmlSerializer(typeof(List<Client>));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, clients);
            }
        }
    }
}
