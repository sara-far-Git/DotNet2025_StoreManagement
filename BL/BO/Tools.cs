using DO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public static class Tools
    {
        public static BO.Client ConvertToBo( DO.Client c)
        {
            return new BO.Client(c.tz, c.name, c.adress, c.phone);
        }
        public static DO.Client ConvertToDo( BO.Client c)
        {
            return new DO.Client(c.tz, c.name, c.adress, c.phone);
        }
        public static BO.Sale ConvertToBo( DO.Sale s)
        {
            return new BO.Sale(s.productId, s.priceSale, s.allSale, s.dateStart, s.dateEnd, s.amount);
        }
        public static DO.Sale ConvertToDo( BO.Sale s)
        {
            return new DO.Sale(s.productId,s.id_uniqe, s.priceSale, s.allSale, s.dateStart, s.dateEnd, s.amount);
        }
        public static BO.Product ConvertToBo( DO.Product p)
        {
            return new BO.Product(p.id, p.name,p.price, p.count, p.category);
        }
        public static DO.Product ConvertToDo( BO.Product p)
        {
            return new DO.Product(p.id, p.name, p.price, p.count,p.category);
        }
        
        public static string ToStringProperty<T>( T obj)
        {
            var result = "";
            var properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                var value = property.GetValue(obj);
                if (value is IEnumerable<object> list && !(value is string))  // אם זה אוסף
                {
                    result += $"{property.Name}: [{string.Join(", ", list.Select(x => x.ToString()))}]\n";
                }
                else
                {
                    result += $"{property.Name}: {value}\n";
                }
            }

            return result;
        }
    }
}