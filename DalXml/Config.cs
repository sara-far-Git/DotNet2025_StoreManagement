using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dal
{
    static internal class Config
    {
        static private string nameFile = @"../xml/data-config.xml";
        const string PRODUCTCODE = "productCode";
        const string SALECODE = "salecode";
        public static string ProductCode
        {
            get
            {
                XElement file = XElement.Load(nameFile);
                string productCodes = file.Attribute(PRODUCTCODE).Value;
                int product = int.Parse(productCodes);
                product++;

                // עדכון הערך החדש בקובץ
                file.SetAttributeValue(PRODUCTCODE, product.ToString());
                file.Save(nameFile);

                return product.ToString();
            }
        }


        public static int SaleCode
        {
            get
            {
                XElement file = XElement.Load(nameFile);
                string saleCodeString = file.Attribute(SALECODE).Value;
                int saleCode = int.Parse(saleCodeString);
                saleCode++;

                // עדכון הערך בקובץ
                file.SetAttributeValue(SALECODE, saleCode.ToString());
                file.Save(nameFile);

                return saleCode;
            }
        }


    }
}
