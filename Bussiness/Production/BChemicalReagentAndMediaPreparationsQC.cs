using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bussiness;
using DataAccess;
using DataAccess.Production;
using Model;
using Model.Production;
using System.Data;


namespace Bussiness.Production
{
    public class BChemicalReagentAndMediaPreparationsQC
    {
        DAChemicalReagentAndMediaPreparationsQC dacrampqc;
        DataSet DS;

        public int chemicalreagentqcdata(MChemicalReagentAndMediaPreparationsQC receive)
        {
            dacrampqc = new DAChemicalReagentAndMediaPreparationsQC();
            int Result = 0;
            try
            {
                Result = dacrampqc.chemicalreagentqcdata(receive);
            }
            catch (Exception)
            {
                throw;
            }
            return Result;
        }

        public DataSet GetChemicalReagentAndMediaPreparationsQCDetailsById(int Id)
        {
            dacrampqc = new DAChemicalReagentAndMediaPreparationsQC();
            return dacrampqc.GetChemicalReagentAndMediaPreparationsQCDetailsById(Id);
        }

        public DataSet GetChemicalReagentAndMediaPreparationsQCDetails()
        {
            dacrampqc = new DAChemicalReagentAndMediaPreparationsQC();
            return dacrampqc.GetChemicalReagentAndMediaPreparationsQCDetails();
        }
    }
}