using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DAMachineAirCompressors
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int machineairdata(MMachineAirCompressors receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("MachineAirCompressorsId", receive.MachineAirCompressorsId));
                paramcollection.Add(new DBParameter("MachineAirCompressorsDate", receive.MachineAirCompressorsDate));
                paramcollection.Add(new DBParameter("MachineAirCompressorsShiftId", receive.MachineAirCompressorsShiftId));
                paramcollection.Add(new DBParameter("StartingTime", receive.StartingTime));
                paramcollection.Add(new DBParameter("EndTime", receive.EndTime));
                paramcollection.Add(new DBParameter("TotalHours", receive.TotalHours));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_MachineAirCompressorsDetails", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetMachineAirCompressorsDetailsById(int MachineAirCompressorsId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("MachineAirCompressorsId", @MachineAirCompressorsId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetMachineAirCompressorsDetailsById", paramcollection, CommandType.StoredProcedure);

            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return DS;
        }

        public DataSet GetMachineAirCompressorsDetails()
        {
            DBParameterCollection paramcollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("sp_Prod_GetMachineAirCompressorsDetails", paramcollection, CommandType.StoredProcedure);
        }
    }
}