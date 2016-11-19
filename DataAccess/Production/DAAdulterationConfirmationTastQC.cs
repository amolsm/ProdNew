using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DAAdulterationConfirmationTastQC
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int adulterationqcdata(MAdulterationConfirmationTastQC receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@RMRId", receive.RMRId));
                paramcollection.Add(new DBParameter("@AdulterationConfirmationTestQCId", receive.AdulterationConfirmationTestQCId   ));
                paramcollection.Add(new DBParameter("@AdulterationConfirmationTestQCDate", receive.AdulterationConfirmationTestQCDate));
                paramcollection.Add(new DBParameter("@AdulterationConfirmationTestQCShiftId", receive.AdulterationConfirmationTestQCShiftId));
                paramcollection.Add(new DBParameter("@Sugar", receive.Sugar));
                paramcollection.Add(new DBParameter("@Starch", receive.Starch));
                paramcollection.Add(new DBParameter("@HydrogenPeroxide", receive.HydrogenPeroxide));
                paramcollection.Add(new DBParameter("@Neutralizer", receive.Neutralizer));
                paramcollection.Add(new DBParameter("@Remarks", receive.Remarks));
                paramcollection.Add(new DBParameter("@AdulterationConfirmationTestQCStatus", receive.AdulterationConfirmationTestQCStatus));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("prod_spAdulterationConfirmationTestQCDetails ", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                String MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetAdulterationConfirmationTastQCDetailsById(int RMRId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RMRId", RMRId));
                DS = _DBHelper.ExecuteDataSet("prod_spGetAdulterationConfirmationTestQCDetailsById", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }

            return DS;
        }

        public DataSet GetAdulterationConfirmationTastQCDetails()
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("prod_spGetAdulterationConfirmationTestQCDetails", paramCollection, CommandType.StoredProcedure);
        }
    }
}