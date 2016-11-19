using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DACurdPackedData
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int curddata(MCurdPackedData receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@CurdPackedDataId", receive.CurdPackedDataId));
                paramcollection.Add(new DBParameter("@RMRId", receive.RMRId));
                paramcollection.Add(new DBParameter("@CurdShiftId", receive.CurdShiftId));
                paramcollection.Add(new DBParameter("@CurdPackedDate", receive.CurdPackedDate));
                paramcollection.Add(new DBParameter("@PackingOperatorName", receive.PackingOperatorName));
                paramcollection.Add(new DBParameter("@ReceivedBy", receive.ReceivedBy));
                paramcollection.Add(new DBParameter("@CurdCupQty", receive.CurdCupQty));
                paramcollection.Add(new DBParameter("@Curd500MLQty", receive.Curd500MLQty));
                paramcollection.Add(new DBParameter("@Curd450MLQty", receive.Curd450MLQty));
                paramcollection.Add(new DBParameter("@ButterMilk200ML", receive.ButterMilk200ML));
                paramcollection.Add(new DBParameter("@TotalQtyOfCurd", receive.TotalQtyOfCurd));
                paramcollection.Add(new DBParameter("@ColdRoomNo", receive.ColdRoomNo));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("prod_spCurdPackedDataDetails", paramcollection, CommandType.StoredProcedure);

            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetCurdPackedDetailsbyId(int RMRId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RMRId", RMRId));
                DS = _DBHelper.ExecuteDataSet("Prod_spCurdPackedDataDetailsById", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }

            return DS;
        }

        public DataSet GetCurdPackedDetails()
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("Prod_spGetCurdPackedDetails", paramCollection, CommandType.StoredProcedure);
        }
    }
}