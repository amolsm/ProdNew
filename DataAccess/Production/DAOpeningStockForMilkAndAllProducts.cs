using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DAOpeningStockForMilkAndAllProducts
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int openingstockdata(MOpeningStockForMilkAndAllProducts receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@RMRId", receive.RMRId));
                paramcollection.Add(new DBParameter("@OpeningStockForMilkAndAllProductsId", receive.OpeningStockForMilkAndAllProductsId));
                paramcollection.Add(new DBParameter("@OpeningStockForMilkAndAllProductsDate", receive.OpeningStockForMilkAndAllProductsDate));
                paramcollection.Add(new DBParameter("@OpeningStockForMilkAndAllProductsShiftId", receive.OpeningStockForMilkAndAllProductsShiftId));
                paramcollection.Add(new DBParameter("@SiloNoForMilk", receive.SiloNoForMilk));
                paramcollection.Add(new DBParameter("@MilkType", receive.MilkType));
                paramcollection.Add(new DBParameter("@Quantity", receive.Quantity));
                paramcollection.Add(new DBParameter("@FAT", receive.FAT));
                paramcollection.Add(new DBParameter("@SNF", receive.SNF));
                paramcollection.Add(new DBParameter("@CLR", receive.CLR));
                paramcollection.Add(new DBParameter("@Temperature", receive.Temperature));
                paramcollection.Add(new DBParameter("@Acidity", receive.Acidity));
                paramcollection.Add(new DBParameter("@MBRT", receive.MBRT));
                paramcollection.Add(new DBParameter("@HomoEfficiency", receive.HomoEfficiency));
                paramcollection.Add(new DBParameter("@Remarks", receive.Remarks));
                paramcollection.Add(new DBParameter("@OpeningStockForMilkAndAllProductsStatus", receive.OpeningStockForMilkAndAllProductsStatus));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("prod_spOpeningStockForMilkAndAllProductsDetails ", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                String MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetOpeningStockForMilkAndAllProductsDetailsById(int RMRId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RMRId", RMRId));
                DS = _DBHelper.ExecuteDataSet("prod_spGetOpeningStockForMilkAndAllProductsDetailsById", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }

            return DS;
        }

        public DataSet GetOpeningStockForMilkAndAllProductsDetails()
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("prod_spGetOpeningStockForMilkAndAllProductsDetails", paramCollection, CommandType.StoredProcedure);
        }
    }
}