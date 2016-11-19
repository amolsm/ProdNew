using System;
using Model.Production;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DataAccess.Production;
using DataAccess;
using Bussiness;
using Model;

namespace Bussiness.Production
{
    public class BClosingStockForMilkInSiloAndAllProducts
    {
        DAClosingStockForMilkInSiloAndAllProducts dacsfmaap;
        DataSet DS;

        public int closingstockdata(MClosingStockForMilkInSiloAndAllProducts receive)
        {
            dacsfmaap = new DAClosingStockForMilkInSiloAndAllProducts();
            int Result = 0;
            try
            {

                Result = dacsfmaap.closingstockdata(receive);

            }
            catch (Exception)
            {
                throw;
            }
            return Result;
        }

        public DataSet GetClosingStockForMilkInSiloAndAllProductsDetailsById(int Id)
        {
            dacsfmaap = new DAClosingStockForMilkInSiloAndAllProducts();
            return dacsfmaap.GetClosingStockForMilkInSiloAndAllProductsDetailsById(Id);
        }

        public DataSet GetClosingStockForMilkInSiloAndAllProductsDetails()
        {
            dacsfmaap = new DAClosingStockForMilkInSiloAndAllProducts();
            return dacsfmaap.GetClosingStockForMilkInSiloAndAllProductsDetails();
        }
    }
}