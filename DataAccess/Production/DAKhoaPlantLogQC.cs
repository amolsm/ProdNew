using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DAKhoaPlantLogQC
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int khoadata(MKhoaPlantLogQC receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@RMRId", receive.RMRId));
                paramcollection.Add(new DBParameter("@KhoaPlantLogQCId", receive.KhoaPlantLogQCId));
                paramcollection.Add(new DBParameter("@KhoaPlantLogQCDate", receive.KhoaPlantLogQCDate));
                paramcollection.Add(new DBParameter("@KhoaPlantLogQCShiftId", receive.KhoaPlantLogQCShiftId));
                paramcollection.Add(new DBParameter("@TypeOfMilk", receive.TypeOfMilk));
                paramcollection.Add(new DBParameter("@SNF", receive.SNF));
                paramcollection.Add(new DBParameter("@Acidity", receive.Acidity));
                paramcollection.Add(new DBParameter("@SugarAddedQuantity", receive.SugarAddedQuantity));
                paramcollection.Add(new DBParameter("@FinalProductQuantity", receive.FinalProductQuantity));
                paramcollection.Add(new DBParameter("@BoilingTemperature", receive.BoilingTemperature));
                paramcollection.Add(new DBParameter("@StartingTime", receive.StartingTime));
                paramcollection.Add(new DBParameter("@EndTime", receive.EndTime));
                paramcollection.Add(new DBParameter("@CleanedBy", receive.CleanedBy));
                paramcollection.Add(new DBParameter("@ChemicalUsed", receive.ChemicalUsed));
                paramcollection.Add(new DBParameter("@Remarks", receive.Remarks));
                paramcollection.Add(new DBParameter("@PreparedBy", receive.PreparedBy));
                paramcollection.Add(new DBParameter("@CheckedBy", receive.CheckedBy));
                paramcollection.Add(new DBParameter("@ApprovedBy", receive.ApprovedBy));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_KhoaPlantLogQCDetails", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                String MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetKhoaPlantlogQCDetailsById(int RMRId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RMRId", RMRId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetKhoaPlantLogQCDetailsById", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }

            return DS;
        }

        public DataSet GetKhoaPlantlogQCDetails()
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("sp_Prod_GetKhoaPlantLogQCDetails", paramCollection, CommandType.StoredProcedure);
        }
    }
}