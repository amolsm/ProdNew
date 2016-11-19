using System;
using Model.Production;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DataAccess.Production;
using DataAccess;
using Bussiness;
using Model;

namespace Bussiness.Production
{
    public class BMicrobiologicalCultureStockRegisterQC
    {
        DAMicrobiologicalCultureStockRegisterQC dambcsrqc;
        DataSet DS;

        public int microbiologicaldata(MMicrobiologicalCultureStockRegisterQC receive)
        {
            dambcsrqc = new DAMicrobiologicalCultureStockRegisterQC();
            int Result = 0;
            try
            {
                Result = dambcsrqc.microbiologicaldata(receive);
            }
            catch (Exception)
            {
                throw;
            }
            return Result;
        }

        public DataSet GetMicrobiologicalCultureStockRegisterQCDetailsById(int Id)
        {
            dambcsrqc = new DAMicrobiologicalCultureStockRegisterQC();
            return dambcsrqc.GetMicrobiologicalCultureStockRegisterQCDetailsById(Id);
        }

        public DataSet GetMicrobiologicalCultureStockRegisterQCDetails()
        {
            dambcsrqc = new DAMicrobiologicalCultureStockRegisterQC();
            return dambcsrqc.GetMicrobiologicalCultureStockRegisterQCDetails();
        }
    }
}