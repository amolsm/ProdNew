using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DAGheeProductionRegister
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int gheedata(MGheeProductionRegister receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@RMRId", receive.RMRId));
                paramcollection.Add(new DBParameter("@GheeProductionRegisterId", receive.GheeProductionRegisterId));
                paramcollection.Add(new DBParameter("@GheeProductionRegisterDate", receive.GheeProductionRegisterDate));
                paramcollection.Add(new DBParameter("@GheeProductionRegisterShiftId", receive.GheeProductionRegisterShiftId));
                paramcollection.Add(new DBParameter("@CreamQualityPhysical", receive.CreamQualityPhysical));
                paramcollection.Add(new DBParameter("@CreamQualityOthers", receive.CreamQualityOthers));
                paramcollection.Add(new DBParameter("@CreamQualityCheckedBy", receive.CreamQualityCheckedBy));
                paramcollection.Add(new DBParameter("@CreamApprovedBy", receive.CreamApprovedBy));
                paramcollection.Add(new DBParameter("@HeatingTemperature", receive.HeatingTemperature));
                paramcollection.Add(new DBParameter("@BoilingStartingTime", receive.BoilingStartingTime));
                paramcollection.Add(new DBParameter("@BoilingEndTime", receive.BoilingEndTime));
                paramcollection.Add(new DBParameter("@SettingStartTime", receive.SettingStartTime));
                paramcollection.Add(new DBParameter("@SettingEndTime", receive.SettingEndTime));
                paramcollection.Add(new DBParameter("@ResidueQuantity", receive.ResidueQuantity));
                paramcollection.Add(new DBParameter("@VesselsCleaning", receive.VesselsCleaning));
                paramcollection.Add(new DBParameter("@InoculationcultureQualityandAcidityFlavour", receive.InoculationcultureQualityandAcidityFlavour));
                paramcollection.Add(new DBParameter("@InoculationcultureQualityandAciditySetting", receive.InoculationcultureQualityandAciditySetting));
                paramcollection.Add(new DBParameter("@InoculationcultureQualityandAcidityTemperature", receive.InoculationcultureQualityandAcidityTemperature));
                paramcollection.Add(new DBParameter("@QualityBeforePackingAppearing", receive.QualityBeforePackingAppearing));
                paramcollection.Add(new DBParameter("@QualityBeforePackingFlavour", receive.QualityBeforePackingFlavour));
                paramcollection.Add(new DBParameter("@FinalProductionQuantity", receive.FinalProductionQuantity));
                paramcollection.Add(new DBParameter("@InspectedBy", receive.InspectedBy));
                paramcollection.Add(new DBParameter("@VerifiedBy", receive.VerifiedBy));
                paramcollection.Add(new DBParameter("@ApprovedBy", receive.ApprovedBy));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_GheeProductionRegisterDetails", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetGheeProductionRegisterDetailsById(int RMRId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RMRId", RMRId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetGheeProductionRegisterDetailsById", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }

            return DS;
        }

        public DataSet GetGheeProductionRegisterDetails()
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("sp_Prod_GetGheeProductionRegisterDetails", paramCollection, CommandType.StoredProcedure);
        }
    }
}