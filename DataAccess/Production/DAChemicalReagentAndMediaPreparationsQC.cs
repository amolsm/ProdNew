using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAcess;
using Model.Production;
using System.Data;

namespace DataAccess.Production
{
    public class DAChemicalReagentAndMediaPreparationsQC
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int chemicalreagentqcdata(MChemicalReagentAndMediaPreparationsQC receive)
        {
            int result = 0;
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("ChemicalReagentAndMediaPreparationsQCId", receive.ChemicalReagentAndMediaPreparationsQCId));
                paramcollection.Add(new DBParameter("ChemicalReagentAndMediaPreparationsQCDate", receive.ChemicalReagentAndMediaPreparationsQCDate));
                paramcollection.Add(new DBParameter("ReagentMfgDate", receive.ReagentMfgDate));
                paramcollection.Add(new DBParameter("ReagentExpDate", receive.ReagentExpDate));
                paramcollection.Add(new DBParameter("SolutionPreparationDate", receive.SolutionPreparationDate));
                paramcollection.Add(new DBParameter("SolutionExpDate", receive.SolutionExpDate));
                paramcollection.Add(new DBParameter("Phosphatase", receive.Phosphatase));
                paramcollection.Add(new DBParameter("Media", receive.Media));
                paramcollection.Add(new DBParameter("MBRT", receive.MBRT));
                paramcollection.Add(new DBParameter("RosalicAcid", receive.RosalicAcid));
                paramcollection.Add(new DBParameter("Neutrilizer", receive.Neutrilizer));
                paramcollection.Add(new DBParameter("SodiumHydrogenCarbonate", receive.SodiumHydrogenCarbonate));
                paramcollection.Add(new DBParameter("SodiumCarbonateAnHydrous", receive.SodiumCarbonateAnHydrous));
                paramcollection.Add(new DBParameter("ParanitrophenylPhosphataseDisodiumSalt", receive.ParanitrophenylPhosphataseDisodiumSalt));
                paramcollection.Add(new DBParameter("DistilledWater", receive.DistilledWater));
                paramcollection.Add(new DBParameter("ReagentQuantity", receive.ReagentQuantity));
                paramcollection.Add(new DBParameter("PreparationQuantity", receive.PreparationQuantity));
                paramcollection.Add(new DBParameter("ReagentLotNo", receive.ReagentLotNo));
                paramcollection.Add(new DBParameter("Others", receive.Others));
                paramcollection.Add(new DBParameter("PreparedBy", receive.PreparedBy));
                paramcollection.Add(new DBParameter("VarifiedBy", receive.VarifiedBy));
                paramcollection.Add(new DBParameter("ApprovedBy", receive.ApprovedBy));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_Prod_ChemicalReagentAndMediaPreparationsQCDetails", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return result;
        }

        public DataSet GetChemicalReagentAndMediaPreparationsQCDetailsById(int ChemicalReagentAndMediaPreparationsQCId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("ChemicalReagentAndMediaPreparationsQCId", @ChemicalReagentAndMediaPreparationsQCId));
                DS = _DBHelper.ExecuteDataSet("sp_Prod_GetChemicalReagentAndMediaPreparationsQCDetailsById", paramcollection, CommandType.StoredProcedure);

            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }
            return DS;
        }

        public DataSet GetChemicalReagentAndMediaPreparationsQCDetails()
        {
            DBParameterCollection paramcollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("sp_Prod_GetChemicalReagentAndMediaPreparationsQCDetails", paramcollection, CommandType.StoredProcedure);
        }
    }
}