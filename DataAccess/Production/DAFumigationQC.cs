using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DAFumigationQC
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int FumigationQCdata(MFumigationQC receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("FumigationQCId", receive.FumigationQCId));
                paramcollection.Add(new DBParameter("FumigationQCDate", receive.FumigationQCDate));
                paramcollection.Add(new DBParameter("FumigationQCShiftId", receive.FumigationQCShiftId));
                paramcollection.Add(new DBParameter("AreaOfExposure", receive.AreaOfExposure));
                paramcollection.Add(new DBParameter("StartingTime", receive.StartingTime));
                paramcollection.Add(new DBParameter("EndTime", receive.EndTime));
                paramcollection.Add(new DBParameter("ChemicalUsed", receive.ChemicalUsed));
                paramcollection.Add(new DBParameter("Merits", receive.Merits));
                paramcollection.Add(new DBParameter("Demerits", receive.Demerits));
                paramcollection.Add(new DBParameter("DoneBy", receive.DoneBy));
                paramcollection.Add(new DBParameter("VerifiedBy", receive.VerifiedBy));
                paramcollection.Add(new DBParameter("ApprovedBy", receive.ApprovedBy));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_FumigationQCDetails", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetFumigationQCDetailsById(int FumigationQCId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@FumigationQCId", FumigationQCId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetFumigationQCDetailsById", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return DS;
        }

        public DataSet GetFumigationQCDetails(string dates)
        { 
            
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@date", dates));
                return _DBHelper.ExecuteDataSet("sp_Prod_GetFumigationQCDetails", paramcollection, CommandType.StoredProcedure);
            
           
        }
        
    }
}