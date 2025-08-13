using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIApi
{
    public interface IOrder
    {
        List<BO.SaleInProduct> AddProductToOrder(BO.Order order, int id, int count);
        void CalcTotalPriceForProduct(BO.ProductInOrder product);
        void CalcTotalPrice(BO.Order order);
        void DoOrder(BO.Order order);
        void SearchSaleForProduct(ProductInOrder product, bool pariority);
    }
}
