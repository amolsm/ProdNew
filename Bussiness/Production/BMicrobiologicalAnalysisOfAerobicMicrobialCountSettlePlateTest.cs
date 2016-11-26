using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bussiness;
using DataAcess;
using DataAccess.Production;
using System.Data;
using Model;
using Model.Production;


namespace Bussiness.Production
{
    public class BMicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTest
    {
        DAMicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTest dambaoamcspt;
        DataSet DS;

        public int MicrobiologicalCountSettlePlateTest(MMicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTest receive)
        {
            dambaoamcspt = new DAMicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTest();
            int Result = 0;
            try
            {
                Result = dambaoamcspt.MicrobiologicalCountSettlePlateTest(receive);
            }
            catch (Exception)
            {
                throw;
            }
            return Result;
        }

        public DataSet GetMicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTestDetailsById(int Id)
        {
            dambaoamcspt = new DAMicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTest();
            return dambaoamcspt.GetMicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTestDetailsById(Id);
        }

        public DataSet GetMicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTestDetails()
        {
            dambaoamcspt = new DAMicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTest();
            return dambaoamcspt.GetMicrobiologicalAnalysisOfAerobicMicrobialCountSettlePlateTestDetails();
        }
    }
}