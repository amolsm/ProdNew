using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DAMachineStartingCondition
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int machinedata(MMachineStartingCondition receive)
        {
            int result = 0;
            try
            { DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("MachineStartingConditionId", receive.MachineStartingConditionId));
                paramcollection.Add(new DBParameter("MachineStartingConditiondDate", receive.MachineStartingConditiondDate));
                paramcollection.Add(new DBParameter("@MachineStartingConditionShiftId", receive.MachineStartingConditionShiftId));
                paramcollection.Add(new DBParameter("@MachineName", receive.MachineName));
                paramcollection.Add(new DBParameter("@Pasteurizer1", receive.Pasteurizer1));
                paramcollection.Add(new DBParameter("@Pasteurizer2", receive.Pasteurizer2));
                paramcollection.Add(new DBParameter("@Homogenizer1", receive.Homogenizer1));
                paramcollection.Add(new DBParameter("@Homogenizer2", receive.Homogenizer2));
                paramcollection.Add(new DBParameter("@SeparatorPump", receive.SeparatorPump));
                paramcollection.Add(new DBParameter("@BDTill", receive.BDTill));
                paramcollection.Add(new DBParameter("@Report", receive.Report));
                paramcollection.Add(new DBParameter("@Service", receive.Service));
                paramcollection.Add(new DBParameter("@Pending", receive.Pending));
                paramcollection.Add(new DBParameter("@MachineConditionStatus", receive.MachineConditionStatus));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("Prod_spMachineStartingConditionDetails", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                String MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetMachineStartingConditionDetailsById(int MachineStartingConditionId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@MachineStartingConditionId", MachineStartingConditionId));
                DS = _DBHelper.ExecuteDataSet("Prod_spMachineStartingConditionDetailsById", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }

            return DS;
        }

        public DataSet GetMachineStartingConditionDetails()
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("Prod_GetspMachineStartingConditionDetails", paramCollection, CommandType.StoredProcedure);
        }
    }
}