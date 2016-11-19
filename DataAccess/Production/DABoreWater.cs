using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DABoreWater
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int borewaterdata(MBoreWater receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("BoreWaterId", receive.BoreWaterId));
                paramcollection.Add(new DBParameter("BoreWaterDate", receive.BoreWaterDate));
                paramcollection.Add(new DBParameter("BoreWaterShiftId", receive.BoreWaterShiftId));
                paramcollection.Add(new DBParameter("OperatedBy", receive.OperatedBy));
                paramcollection.Add(new DBParameter("StartingTime", receive.StartingTime));
                paramcollection.Add(new DBParameter("EndTime", receive.EndTime));
                paramcollection.Add(new DBParameter("TotalHours", receive.TotalHours));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_BoreWaterDetails", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetBoreWaterDetailsById(int BoreWaterId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("BoreWaterId", @BoreWaterId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetBoreWaterDetailsById", paramcollection, CommandType.StoredProcedure);

            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return DS;
        }

        public DataSet GetBoreWaterDetails()
        {
            DBParameterCollection paramcollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("sp_Prod_GetBoreWaterDetails", paramcollection, CommandType.StoredProcedure);
        }
    }
}