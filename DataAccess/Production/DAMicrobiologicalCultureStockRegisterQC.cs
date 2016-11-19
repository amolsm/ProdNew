using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DAMicrobiologicalCultureStockRegisterQC
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int microbiologicaldata(MMicrobiologicalCultureStockRegisterQC receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@MicrobiologicalCultureStockRegisterQCId", receive.MicrobiologicalCultureStockRegisterQCId));
                paramcollection.Add(new DBParameter("@MicrobiologicalStockDate", receive.MicrobiologicalStockDate));
                paramcollection.Add(new DBParameter("@ReceivedDate", receive.ReceivedDate));
                paramcollection.Add(new DBParameter("@PackingDate", receive.PackingDate));
                paramcollection.Add(new DBParameter("@OpeningStock", receive.OpeningStock));
                paramcollection.Add(new DBParameter("@Receipt", receive.Receipt));
                paramcollection.Add(new DBParameter("@Issue", receive.Issue));
                paramcollection.Add(new DBParameter("@Damage", receive.Damage));
                paramcollection.Add(new DBParameter("@Returned", receive.Returned));
                paramcollection.Add(new DBParameter("@ClosingStock", receive.ClosingStock));
                paramcollection.Add(new DBParameter("@CultureUsed", receive.CultureUsed));
                paramcollection.Add(new DBParameter("@VerifiedBy", receive.VerifiedBy));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_MicrobiologicalCultureStockRegisterQCDetails", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetMicrobiologicalCultureStockRegisterQCDetailsById(int MicrobiologicalCultureStockRegisterQCId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@MicrobiologicalCultureStockRegisterQCId", MicrobiologicalCultureStockRegisterQCId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetMicrobiologicalCultureStockRegisterQCDetailsById", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return DS;
        }

        public DataSet GetMicrobiologicalCultureStockRegisterQCDetails()
        {
            DBParameterCollection paramcollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("sp_Prod_GetMicrobiologicalCultureStockRegisterQCDetails", paramcollection, CommandType.StoredProcedure);
        }
    }
}