using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DAEffluentTreatmentPlant
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int effluntplantdata(MEffluentTreatmentPlant receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("EffluentTreatmentPlantId", receive.EffluentTreatmentPlantId));
                paramcollection.Add(new DBParameter("EffluentTreatmentPlantDate", receive.EffluentTreatmentPlantDate));
                paramcollection.Add(new DBParameter("EffluentTreatmentPlantShiftId", receive.EffluentTreatmentPlantShiftId));
                paramcollection.Add(new DBParameter("OperatedBy", receive.OperatedBy));
                paramcollection.Add(new DBParameter("Remarks", receive.Remarks));
                paramcollection.Add(new DBParameter("CollectionPumpAStartingTime", receive.CollectionPumpAStartingTime));
                paramcollection.Add(new DBParameter("CollectionPumpAEndTime", receive.CollectionPumpAEndTime));
                paramcollection.Add(new DBParameter("CollectionPumpATotalRunningHours", receive.CollectionPumpATotalRunningHours));
                paramcollection.Add(new DBParameter("CollectionPumpBStartingTime", receive.CollectionPumpBStartingTime));
                paramcollection.Add(new DBParameter("CollectionPumpBEndTime", receive.CollectionPumpBEndTime));
                paramcollection.Add(new DBParameter("CollectionPumpBTotalRunningHours", receive.CollectionPumpBTotalRunningHours));
                paramcollection.Add(new DBParameter("AERATORStartingTime", receive.AERATORStartingTime));
                paramcollection.Add(new DBParameter("AERATOREndTime", receive.AERATOREndTime));
                paramcollection.Add(new DBParameter("AERATORTotalRunningHours", receive.AERATORTotalRunningHours));
                paramcollection.Add(new DBParameter("BLOWERAStartingTime", receive.BLOWERAStartingTime));
                paramcollection.Add(new DBParameter("BLOWERAEndTime", receive.BLOWERAEndTime));
                paramcollection.Add(new DBParameter("BLOWERATotalRunningHours", receive.BLOWERATotalRunningHours));
                paramcollection.Add(new DBParameter("BLOWERBStartingTime", receive.BLOWERBStartingTime));
                paramcollection.Add(new DBParameter("BLOWERBEndTime", receive.BLOWERBEndTime));
                paramcollection.Add(new DBParameter("BLOWERBTotalRunningHours", receive.BLOWERBTotalRunningHours));
                paramcollection.Add(new DBParameter("ClarifierMechanismStartingTime", receive.ClarifierMechanismStartingTime));
                paramcollection.Add(new DBParameter("ClarifierMechanismEndTime", receive.ClarifierMechanismEndTime));
                paramcollection.Add(new DBParameter("ClarifierMechanismTotalRunningHours", receive.ClarifierMechanismTotalRunningHours));
                paramcollection.Add(new DBParameter("SludgeReCirculationPumpAStartingTime", receive.SludgeReCirculationPumpAStartingTime));
                paramcollection.Add(new DBParameter("SludgeReCirculationPumpAEndTime", receive.SludgeReCirculationPumpAEndTime));
                paramcollection.Add(new DBParameter("SludgeReCirculationPumpATotalRunningHours", receive.SludgeReCirculationPumpATotalRunningHours));
                paramcollection.Add(new DBParameter("SludgeReCirculationPumpBStartingTime", receive.SludgeReCirculationPumpBStartingTime));
                paramcollection.Add(new DBParameter("SludgeReCirculationPumpBEndTime", receive.SludgeReCirculationPumpBEndTime));
                paramcollection.Add(new DBParameter("SludgeReCirculationPumpBTotalRunningHours", receive.SludgeReCirculationPumpBTotalRunningHours));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_EffluentTreatmentPlantDetails", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetEffluentTreatmentPlantDetailsById(int EffluentTreatmentPlantId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("EffluentTreatmentPlantId", @EffluentTreatmentPlantId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetEffluentTreatmentPlantDetailsById", paramcollection, CommandType.StoredProcedure);

            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return DS;
        }

        public DataSet GetEffluentTreatmentPlantDetails()
        {
            DBParameterCollection paramcollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("sp_Prod_GetEffluentTreatmentPlantDetails", paramcollection, CommandType.StoredProcedure);
        }
    }

}