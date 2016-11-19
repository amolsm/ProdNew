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
    public class BOpeningStockForMilkAndAllProducts
    {
        DAOpeningStockForMilkAndAllProducts daosfmaap;
        DataSet DS;

        public int openingstockdata(MOpeningStockForMilkAndAllProducts receive)
        {
            daosfmaap = new DAOpeningStockForMilkAndAllProducts();
            int Result = 0;
            try
            {

                Result = daosfmaap.openingstockdata(receive);

            }
            catch (Exception)
            {
                throw;
            }
            return Result;
        }

        public DataSet GetOpeningStockForMilkAndAllProductsDetailsById(int Id)
        {
            daosfmaap = new DAOpeningStockForMilkAndAllProducts();
            return daosfmaap.GetOpeningStockForMilkAndAllProductsDetailsById(Id);
        }

        public DataSet GetOpeningStockForMilkAndAllProductsDetails()
        {
            daosfmaap = new DAOpeningStockForMilkAndAllProducts();
            return daosfmaap.GetOpeningStockForMilkAndAllProductsDetails();
        }
    }
}