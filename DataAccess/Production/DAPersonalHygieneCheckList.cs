using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DAPersonalHygieneCheckList
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int personalhygienedata(MPersonalHygieneCheckList receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("PersonalHygieneCheckListId", receive.PersonalHygieneCheckListId));
                paramcollection.Add(new DBParameter("PersonalHygieneCheckListDate", receive.PersonalHygieneCheckListDate));
                paramcollection.Add(new DBParameter("EmployeeName", receive.EmployeeName));
                paramcollection.Add(new DBParameter("DesignationOfEmp", receive.DesignationOfEmp));
                paramcollection.Add(new DBParameter("UniformCleaning", receive.UniformCleaning));
                paramcollection.Add(new DBParameter("Nail", receive.Nail));
                paramcollection.Add(new DBParameter("Cap", receive.Cap));
                paramcollection.Add(new DBParameter("ApronLab", receive.ApronLab));
                paramcollection.Add(new DBParameter("BeardCrimp", receive.BeardCrimp));
                paramcollection.Add(new DBParameter("HandGloves", receive.HandGloves));
                paramcollection.Add(new DBParameter("Mask", receive.Mask));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_PersonalHygieneCheckListDetails", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetPersonalHygieneCheckListDetailsById(int PersonalHygieneCheckListId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("PersonalHygieneCheckListId", @PersonalHygieneCheckListId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetPersonalHygieneCheckListDetailsById", paramcollection, CommandType.StoredProcedure);

            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return DS;
        }

        public DataSet GetPersonalHygieneCheckListDetails()
        {
            DBParameterCollection paramcollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("sp_Prod_GetPersonalHygieneCheckListDetails", paramcollection, CommandType.StoredProcedure);
        }
    }
}