using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DAMachineComplaintsAndRectifiedRecord
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;
        //
        public int machinereportdata(MMachineComplaintsAndRectifiedRecord receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@MachineComplaintsAndRectifiedRecordId", receive.MachineComplaintsAndRectifiedRecordId));
                paramcollection.Add(new DBParameter("@MachineComplaintsAndRectifiedRecordDate", receive.MachineComplaintsAndRectifiedRecordDate));
                paramcollection.Add(new DBParameter("@MachineComplaintsAndRectifiedRecordShiftId", receive.MachineComplaintsAndRectifiedRecordShiftId));
                paramcollection.Add(new DBParameter("@MachineName", receive.MachineName));
                paramcollection.Add(new DBParameter("@IdentifiedBy", receive.IdentifiedBy));
                paramcollection.Add(new DBParameter("@RectifiedBy", receive.RectifiedBy));
                paramcollection.Add(new DBParameter("@RectifiedDate", receive.RectifiedDate));
                paramcollection.Add(new DBParameter("@MachineRectifiedStatus", receive.MachineRectifiedStatus));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("prod_spMachineComplaintsAndRectifiedDetails", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                String MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetMachineComplaintsAndRectifiedDetailsById(int MachineComplaintsAndRectifiedRecordId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@MachineComplaintsAndRectifiedRecordId", MachineComplaintsAndRectifiedRecordId));
                DS = _DBHelper.ExecuteDataSet("prod_spGetMachineComplaintsAndRectifiedDetailsById", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }

            return DS;
        }

        public DataSet GetMachineComplaintsAndRectifiedDetails()
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("prod_spGetMachineComplaintsAndRectifiedDetails", paramCollection, CommandType.StoredProcedure);
        }
    }
}