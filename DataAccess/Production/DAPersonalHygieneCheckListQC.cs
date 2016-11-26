using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DAPersonalHygieneCheckListQC
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int personalhygieneqcdata(MPersonalHygieneCheckListQC receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("PersonalHygieneCheckListQCId", receive.PersonalHygieneCheckListQCId));
                paramcollection.Add(new DBParameter("PersonalHygieneCheckListQCDate", receive.PersonalHygieneCheckListQCDate));
                paramcollection.Add(new DBParameter("EmployeeId", receive.EmployeeId));
                paramcollection.Add(new DBParameter("DesignationId", receive.DesignationId));
                paramcollection.Add(new DBParameter("UniformCleaning", receive.UniformCleaning));
                paramcollection.Add(new DBParameter("Nail", receive.Nail));
                paramcollection.Add(new DBParameter("Cap", receive.Cap));
                paramcollection.Add(new DBParameter("ApronLab", receive.ApronLab));
                paramcollection.Add(new DBParameter("BeardCrimp", receive.BeardCrimp));
                paramcollection.Add(new DBParameter("HandGloves", receive.HandGloves));
                paramcollection.Add(new DBParameter("Mask", receive.Mask));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_PersonalHygieneCheckListQCDetails", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetPersonalHygieneCheckListQCDetailsById(int PersonalHygieneCheckListQCId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("PersonalHygieneCheckListQCId", @PersonalHygieneCheckListQCId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetPersonalHygieneCheckListQCDetailsById", paramcollection, CommandType.StoredProcedure);

            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return DS;
        }

        public DataSet GetPersonalHygieneCheckListQCDetails()
        {
            DBParameterCollection paramcollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("sp_Prod_GetPersonalHygieneCheckListQCDetails", paramcollection, CommandType.StoredProcedure);
        }
    }
}