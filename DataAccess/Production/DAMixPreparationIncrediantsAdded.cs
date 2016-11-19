using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;
namespace DataAccess.Production
{
    public class DAMixPreparationIncrediantsAdded
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int mixpreparationdata(MMixPreparationIncrediantsAdded receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@RMRId", receive.RMRId));
                paramcollection.Add(new DBParameter("@MixPreparationIncrediantsAddedId", receive.MixPreparationIncrediantsAddedId));
                paramcollection.Add(new DBParameter("@MixPreparationIncrediantsAddedDate", receive.MixPreparationIncrediantsAddedDate));
                paramcollection.Add(new DBParameter("@MixPreparationIncrediantsAddedShiftId", receive.MixPreparationIncrediantsAddedShiftId));
                paramcollection.Add(new DBParameter("@SMP", receive.SMP));
                paramcollection.Add(new DBParameter("@Cream", receive.Cream));
                paramcollection.Add(new DBParameter("@Milk", receive.Milk));
                paramcollection.Add(new DBParameter("@Sugar", receive.Sugar));
                paramcollection.Add(new DBParameter("@Stabilizer", receive.Stabilizer));
                paramcollection.Add(new DBParameter("@Emulsifier", receive.Emulsifier));
                paramcollection.Add(new DBParameter("@TotalMixQty", receive.TotalMixQty));
                paramcollection.Add(new DBParameter("@Remarks", receive.Remarks));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_PreparationIncrediantsAddedDetails", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetMixPreparationIncrediantsAddedDetailsById(int RMRId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RMRId", RMRId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetPreparationIncrediantsAddedDetailsById", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }

            return DS;
        }

        public DataSet GetMixPreparationIncrediantsAddedDetails()
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("sp_Prod_GetPreparationIncrediantsAddedDetails", paramCollection, CommandType.StoredProcedure);
        }
    }
}