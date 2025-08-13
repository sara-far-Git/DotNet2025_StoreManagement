using BIApi;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BO.Tools;

namespace BlImplementation
{
    public class OrderImplementation : IOrder
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;
        public List<SaleInProduct> AddProductToOrder(Order order, int id, int count)
        {
            DO.Product product=_dal.Product.Read(id);
            if (product == null)
            {
                throw new BlDoesNotExistException("המוצר לא קיים");
            }
            BO.ProductInOrder productInOrder = order.productInOrders.FirstOrDefault(x => x.productId == id);
            if (productInOrder == null)
            {
                if (product.count > 0)
                {
                    int amount = (int)(product.count - count);
                    productInOrder.count = amount;
                }
                else
                {
                    throw new BlDoesNotExistException("המוצר לא קיים במלאי");
                }
            }
            BO.ProductInOrder productInOrder1 = new BO.ProductInOrder(id, product.name, product.price ?? 0, productInOrder.count, new List<SaleInProduct>(), 0);
            order.productInOrders.Add(productInOrder1);
            SearchSaleForProduct(productInOrder1, order.pariority);
            CalcTotalPriceForProduct(productInOrder1 );
            CalcTotalPrice(order);
            return productInOrder1.saleInProducts;
        }

        public void CalcTotalPrice(Order order)
        {
            order.lastPrice = order.productInOrders.Sum(s => s.lastPrice);
        }

        public void CalcTotalPriceForProduct(ProductInOrder product)
        {
            int count=product.count;
            List<SaleInProduct> sales = new List<SaleInProduct>();
            foreach (var item in product.saleInProducts)
            {
                if(count>=item.count)
                {
                    int amount = item.count / count;
                    double totalPrice=item.price*amount;
                    product.count= count - amount;                   
                    sales.Add(item);   
                }
                if(count==0)
                    break;
            }
            product.saleInProducts = sales;
            product.lastPrice += product.count * product.basicPrice;
        }

        public void DoOrder(Order order)
        {
            List<ProductInOrder> productInOrders=order.productInOrders;
            foreach (var item in productInOrders)
            {
                DO.Product product = _dal.Product.Read(item.productId);
                if(product!=null)
                {
                    if (product.count < item.count)
                        throw new DO.DalNotFound("המוצר לא קיים");
                    int num=product.count.Value-item.count;
                    DO.Product product1=product with { count=num };
                    _dal.Product.Update(product1);
                }
                else
                {
                    throw new DO.DalNotFound("המוצר לא קיים");
                }
            }
        }

        public void SearchSaleForProduct(ProductInOrder product, bool pariority)
        {
            List<SaleInProduct> sales=product.saleInProducts;
            product.saleInProducts=_dal.Sale.ReadAll(x=>x.productId==product.productId&&x.dateStart<=DateTime.Now&&x.dateEnd>DateTime.Now
            &&product.count>=x.amount&&x.allSale!=pariority).Select(x=> new SaleInProduct( x.productId,x.priceSale,x.priceSale,true)).OrderBy(x=>x.price/x.count).ToList();
        }
    }
}
