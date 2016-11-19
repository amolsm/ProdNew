using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DAIceCreamColdRoomTemperature
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int icecreamdata(MIceCreamColdRoomTemperature receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@IceCreamColdRoomTemperatureId", receive.IceCreamColdRoomTemperatureId));
                paramcollection.Add(new DBParameter("@RMRId", receive.RMRId));
                paramcollection.Add(new DBParameter("@IceCreamColdRoomTemperatureDate", receive.IceCreamColdRoomTemperatureDate));
                paramcollection.Add(new DBParameter("@IceCreamColdRoomTemperatureShiftId", receive.IceCreamColdRoomTemperatureShiftId));
                paramcollection.Add(new DBParameter("@HardeningRoom", receive.HardeningRoom));
                paramcollection.Add(new DBParameter("@AgingTank", receive.AgingTank));
                paramcollection.Add(new DBParameter("@CandyTank", receive.CandyTank));
                paramcollection.Add(new DBParameter("@ColdStorageRoom", receive.ColdStorageRoom));
                paramcollection.Add(new DBParameter("@IBTTemperature", receive.IBTTemperature));
                paramcollection.Add(new DBParameter("@CheckedBy", receive.CheckedBy));
                paramcollection.Add(new DBParameter("@verifierBy", receive.verifierBy));
                paramcollection.Add(new DBParameter("@BreakAndDownServices", receive.BreakAndDownServices));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_IceCreamRoomTemperaturDetails", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetIceCreamColdRoomTemperatureDetailsById(int RMRId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@RMRId", RMRId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetIceCreamRoomTemperaturDetailsById", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                String MSG = EX.ToString();
            }
            return DS;
        }

        public DataSet GetIceCreamColdRoomTemperatureDetails()
        {
            DBParameterCollection paramcollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("sp_Prod_GetIceCreamRoomTemperaturDetails", paramcollection, CommandType.StoredProcedure);
        }
    }
}