using BlApi;
using BO;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BO.Tools;
using BO;

namespace BlImplementation
{
    public class ProductImplementation : IProduct
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;
        public int Create(BO.Product item)
        {
            try
            {
                return _dal.Product.Create(ConvertToDo(item));

            }
            catch(DO.DalNotFound ex)
            {
                throw new DO.DalNotFound(ex.Message); 
            }
        }

        public void Delete(int id)
        {
            try
            {
                _dal.Product.Delete(id);
            }
            catch (DO.DalNotFound ex)
            {
                throw new DO.DalNotFound(ex.Message);
            }
        }


        public BO.Product? Read(int id)
        {
            try
            {
                DO.Product productDo= _dal.Product.Read(id);
                if(productDo == null)
                    return null;
                return ConvertToBo(productDo);
            }
            catch(DO.DalNotFound ex)
            {
               throw new DalNotFound(ex.Message);
            }
        }

        public List<BO.Product?> ReadAll(Func<BO.Product, bool>? filter = null)
        {
            try
            {
                // קריאת כל המוצרים מ-DAL
                List<DO.Product> products = _dal.Product.ReadAll();

                // המרה ל-BO
                var boProducts = products
                    .Select(p => ConvertToBo(p))
                    .Where(p => filter == null || filter(p!))
                    .ToList();

                return boProducts;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to read all products.", ex);
            }
        }

        public void Update(BO.Product item)
        {
            try
            {
                DO.Product product = ConvertToDo(item);
                _dal.Product.Update(product);
            }
            catch (DO.DalNotFound ex)
            {
                throw new DalNotFound(ex.Message);
            }
        }
        public List<SaleInProduct> AllSalesInValidity(int id,bool pariority)
        {
            try
            {
                return _dal.Sale.ReadAll(sale => sale.productId == id && sale.dateStart <= DateTime.Now && sale.dateEnd >= DateTime.Now && (pariority || !order.paryoriry))
                     .Select(s => new BO.SaleInProduct(s.saleId, s.AmountForSale, s.PriceForSale, pariority)).ToList();
            
            }
            catch (DO.DalNotFound ex)
            {
                throw new DO.DalNotFound(ex.Message);
            }
        }
    }
}
