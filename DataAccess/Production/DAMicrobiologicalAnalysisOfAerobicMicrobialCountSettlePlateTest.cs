using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DAMicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTest
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int MicrobiologicalCountSettlePlateTest(MMicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTest receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("MicrobiologicalAnalysisofAerobicMicrobialCountSettlePlateTestId", receive.MicrobiologicalAnalysisofAerobicMicrobialCountSettlePlateTestId));
                paramcollection.Add(new DBParameter("MicrobiologicalAnalysisofAerobicMicrobialCountSettlePlateTestDate", receive.MicrobiologicalAnalysisofAerobicMicrobialCountSettlePlateTestDate));
                paramcollection.Add(new DBParameter("MicrobiologicalAnalysisofAerobicMicrobialCountSettlePlateTestShiftId", receive.MicrobiologicalAnalysisofAerobicMicrobialCountSettlePlateTestShiftId));
                paramcollection.Add(new DBParameter("AreaOfExposure", receive.AreaOfExposure));
                paramcollection.Add(new DBParameter("StartingTime", receive.StartingTime));
                paramcollection.Add(new DBParameter("EndTime", receive.EndTime));
                paramcollection.Add(new DBParameter("TBCCount", receive.TBCCount));
                paramcollection.Add(new DBParameter("yeastAndMouldCount", receive.yeastAndMouldCount));
                paramcollection.Add(new DBParameter("Merits", receive.Merits));
                paramcollection.Add(new DBParameter("Demerits", receive.Demerits));
                paramcollection.Add(new DBParameter("CheckedBy", receive.CheckedBy));
                paramcollection.Add(new DBParameter("VerifiedBy", receive.VerifiedBy));
                paramcollection.Add(new DBParameter("ApprovedBy", receive.ApprovedBy));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_MicrobiologicalAnalysisofAerobicMicrobialCountSettlePlateTestDetails", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetMicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTestDetailsById(int MicrobiologicalAnalysisofAerobicMicrobialCountSettlePlateTestId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("MicrobiologicalAnalysisofAerobicMicrobialCountSettlePlateTestId", @MicrobiologicalAnalysisofAerobicMicrobialCountSettlePlateTestId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetMicrobiologicalAnalysisofAerobicMicrobialCountSettlePlateTestDetailsById", paramcollection, CommandType.StoredProcedure);

            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return DS;
        }

        public DataSet GetMicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTestDetails()
        {
            DBParameterCollection paramcollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("sp_Prod_GetMicrobiologicalAnalysisofAerobicMicrobialCountSettlePlateTestDetails", paramcollection, CommandType.StoredProcedure);
        }
    }
}