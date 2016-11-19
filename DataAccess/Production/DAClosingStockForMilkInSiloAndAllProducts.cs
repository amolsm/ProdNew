using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;


namespace DataAccess.Production
{
    public class DAClosingStockForMilkInSiloAndAllProducts
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int closingstockdata(MClosingStockForMilkInSiloAndAllProducts receive)
        { 
         int result = 0;
         try
         { 
         
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@RMRId", receive.RMRId));
                paramcollection.Add(new DBParameter("@ClosingStockForMilkInSiloAndAllProductsId", receive.ClosingStockForMilkInSiloAndAllProductsId));
                paramcollection.Add(new DBParameter("@ClosingStockForMilkInSiloAndAllProductsDate", receive.ClosingStockForMilkInSiloAndAllProductsDate));
                paramcollection.Add(new DBParameter("@ClosingStockForMilkInSiloAndAllProductsShiftId", receive.ClosingStockForMilkInSiloAndAllProductsShiftId));
                paramcollection.Add(new DBParameter("@SiloNo", receive.SiloNo));
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
                paramcollection.Add(new DBParameter("@ClosingStockForMilkInSiloAndAllProductsStatus", receive.ClosingStockForMilkInSiloAndAllProductsStatus));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("prod_spClosingStockForMilkInSiloAndAllProductsDetails ", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                String MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetClosingStockForMilkInSiloAndAllProductsDetailsById(int RMRId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RMRId", RMRId));
                DS = _DBHelper.ExecuteDataSet("prod_spGetClosingStockForMilkInSiloAndAllProductsDetailsById", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }

            return DS;
        }

        public DataSet GetClosingStockForMilkInSiloAndAllProductsDetails()
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("prod_spGetClosingStockForMilkInSiloAndAllProductsDetails", paramCollection, CommandType.StoredProcedure);
        }
    }
}
    