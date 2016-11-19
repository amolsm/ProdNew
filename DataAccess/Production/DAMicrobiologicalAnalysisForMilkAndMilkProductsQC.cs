using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DAMicrobiologicalAnalysisForMilkAndMilkProductsQC
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int microbiologicalmilkproductdata(MMicrobiologicalAnalysisForMilkAndMilkProductsQC receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@MicrobiologicalAnalysisForMilkAndMilkProductsQCId", receive.MicrobiologicalAnalysisForMilkAndMilkProductsQCId));
                paramcollection.Add(new DBParameter("@MicrobiologicalAnalysisForMilkAndMilkProductsQCDate", receive.MicrobiologicalAnalysisForMilkAndMilkProductsQCDate));
                paramcollection.Add(new DBParameter("@MicrobiologicalAnalysisForMilkAndMilkProductsQCShiftId", receive.MicrobiologicalAnalysisForMilkAndMilkProductsQCShiftId));
                paramcollection.Add(new DBParameter("@TestedBy", receive.TestedBy));
                paramcollection.Add(new DBParameter("@ActionTakenBy", receive.ActionTakenBy));
                paramcollection.Add(new DBParameter("@VerifiedBy", receive.VerifiedBy));
                paramcollection.Add(new DBParameter("@SampleTakenPlace", receive.SampleTakenPlace));
                paramcollection.Add(new DBParameter("@SampleTestingTime", receive.SampleTestingTime));
                paramcollection.Add(new DBParameter("@ColiForm", receive.ColiForm));
                paramcollection.Add(new DBParameter("@TBCCFUAndML", receive.TBCCFUAndML));
                paramcollection.Add(new DBParameter("@YeastAndMouldCFUAndML", receive.YeastAndMouldCFUAndML));
                paramcollection.Add(new DBParameter("@CorrectiveActionRequired", receive.CorrectiveActionRequired));
                paramcollection.Add(new DBParameter("@Remarks", receive.Remarks));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_MicrobiologicalAnalysisForMilkAndMilkProductsQCDetails", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetMicrobiologicalAnalysisForMilkAndMilkProductsQCDetailsById(int MicrobiologicalAnalysisForMilkAndMilkProductsQCId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@MicrobiologicalAnalysisForMilkAndMilkProductsQCId", MicrobiologicalAnalysisForMilkAndMilkProductsQCId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetMicrobiologicalAnalysisForMilkAndMilkProductsQCDetailsById", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }

            return DS;
        }

        public DataSet GetMicrobiologicalAnalysisForMilkAndMilkProductsQCDetails()
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("sp_Prod_GetMicrobiologicalAnalysisForMilkAndMilkProductsQCDetails", paramCollection, CommandType.StoredProcedure);
        }
    }
}