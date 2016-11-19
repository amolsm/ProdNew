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
    public class BIceCreamMixProcessing
    {
        DAIceCreamMixProcessing daimp;
        DataSet DS;

        public int icecreamdata(MIceCreamMixProcessing receive)
        {
            daimp = new DAIceCreamMixProcessing();
            int Result = 0;
            try
            {
                Result = daimp.icecreamdata(receive);

            }
            catch (Exception )
            {
                throw;
            }
            return Result;
        }

        public DataSet GetIceCreamMixProcessingDetailsById(int Id)
        {
            daimp = new DAIceCreamMixProcessing();
            return daimp.GetIceCreamMixProcessingDetailsById(Id);
        }

        public DataSet GetIceCreamMixProcessingDetails()
        {
            daimp = new DAIceCreamMixProcessing();
            return daimp.GetIceCreamMixProcessingDetails();
        }
    }
}