using BlApi;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BO.Tools;

namespace BlImplementation
{
    public class SaleImplementation : ISale
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;
        public int Create(BO.Sale item)
        {
            try
            {
                return _dal.Sale.Create(Con);
            }
            catch(DO.DalFound ex)
            {
                new DO.DalFound(ex.Message);
            }
            return 0;
        }

        public void Delete(int id)
        {
            try
            {
                _dal.Sale.Delete(id);
            }
            catch(DO.DalNotFound ex)
            {
                throw new DO.DalNotFound(ex.Message);
            }
        }

        public Sale? Read(int id)
        {
            try
            {
                DO.Sale saleDo = _dal.Sale.Read(id);
                if (saleDo == null)
                    return null;
                return saleDo.ConvertToBo();
            }
            catch(DO.DalNotFound ex)
            {
                throw new DO.DalNotFound(ex.ToString());
            }
        }



        public List<Sale?> ReadAll(Func<Sale, bool>? filter = null)
        {
            try
            {
                List<DO.Sale> salesDo = _dal.Sale.ReadAll();

                var salesBo = salesDo
                    .Select(s => s.ConvertToBo())
                    .Where(s => filter == null || filter(s!))
                    .ToList();

                return salesBo;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to read all sales.", ex);
            }
        }

        public void Update(Sale item)
        {
            try
            {
                DO.Sale sale = item.ConvertToDo();
                _dal.Sale.Update(sale);
            }
            catch (DO.DalNotFound ex)
            {
                throw new DO.DalNotFound(ex.Message);
            }
        }
    }
}
