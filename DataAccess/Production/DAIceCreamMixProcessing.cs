using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DAIceCreamMixProcessing
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int icecreamdata(MIceCreamMixProcessing receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@IceCreamMixProcessingId", receive.IceCreamMixProcessingId));
                paramcollection.Add(new DBParameter("@RMRId", receive.RMRId));
                paramcollection.Add(new DBParameter("@IceCreamMixProcessingDate", receive.IceCreamMixProcessingDate));
                paramcollection.Add(new DBParameter("@IceCreamMixProcessingShiftId", receive.IceCreamMixProcessingShiftId));
                paramcollection.Add(new DBParameter("@StartingTime", receive.StartingTime));
                paramcollection.Add(new DBParameter("@EndTime", receive.EndTime));
                paramcollection.Add(new DBParameter("@BatchQuantity", receive.BatchQuantity));
                paramcollection.Add(new DBParameter("@HeatTemperature", receive.HeatTemperature));
                paramcollection.Add(new DBParameter("@homogenizerPressureStage1", receive.homogenizerPressureStage1));
                paramcollection.Add(new DBParameter("@HomogenizerPressureStage2", receive.HomogenizerPressureStage2));
                paramcollection.Add(new DBParameter("@ChillingTemperature", receive.ChillingTemperature));
                paramcollection.Add(new DBParameter("@AGINGStartingTime", receive.AGINGStartingTime));
                paramcollection.Add(new DBParameter("@AGINGEndTime", receive.AGINGEndTime));
                paramcollection.Add(new DBParameter("@FinalTemperatureInAGINGVAT", receive.FinalTemperatureInAGINGVAT));
                paramcollection.Add(new DBParameter("@OperatedBy", receive.OperatedBy));
                paramcollection.Add(new DBParameter("@TechnicianName", receive.TechnicianName));
                paramcollection.Add(new DBParameter("@Remarks", receive.Remarks));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_IceCreamMixProcessingDetails", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                String MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetIceCreamMixProcessingDetailsById(int RMRId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@RMRId", RMRId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetIceCreamMixProcessingDetailsById", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return DS;
        }

        public DataSet GetIceCreamMixProcessingDetails()
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("sp_Prod_GetIceCreamMixProcessingDetails", paramCollection, CommandType.StoredProcedure);
        }
    }
}