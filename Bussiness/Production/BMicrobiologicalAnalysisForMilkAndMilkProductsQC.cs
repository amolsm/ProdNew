using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using Model.Production;
using DataAccess;
using DataAccess.Production;
using Bussiness;
using System.Data;

namespace Bussiness.Production
{
    public class BMicrobiologicalAnalysisForMilkAndMilkProductsQC
    {
        DAMicrobiologicalAnalysisForMilkAndMilkProductsQC dambafmampqc;
        DataSet DS;

        public int microbiologicalmilkproductdata(MMicrobiologicalAnalysisForMilkAndMilkProductsQC receive)
        {
            dambafmampqc = new DAMicrobiologicalAnalysisForMilkAndMilkProductsQC();
            int Result = 0;
            try
            {
                Result = dambafmampqc.microbiologicalmilkproductdata(receive);
            }
            catch (Exception)
            {
                throw;
            }
            return Result;
        }

        public DataSet GetMicrobiologicalAnalysisForMilkAndMilkProductsQCDetailsById(int MicrobiologicalAnalysisForMilkAndMilkProductsQCId)
        {
            dambafmampqc = new DAMicrobiologicalAnalysisForMilkAndMilkProductsQC();
            return dambafmampqc.GetMicrobiologicalAnalysisForMilkAndMilkProductsQCDetailsById(MicrobiologicalAnalysisForMilkAndMilkProductsQCId);
        }

        public DataSet GetMicrobiologicalAnalysisForMilkAndMilkProductsQCDetails()
        {

            dambafmampqc = new DAMicrobiologicalAnalysisForMilkAndMilkProductsQC();
            return dambafmampqc.GetMicrobiologicalAnalysisForMilkAndMilkProductsQCDetails();
        }
    }
}