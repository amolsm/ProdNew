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
    public class BCurdPackedData
    {
        DACurdPackedData dacurddata;
        DataSet DS;

        public int curddata(MCurdPackedData receive)
        {

            dacurddata = new DACurdPackedData();
            int Result = 0;
            try
            {
                Result = dacurddata.curddata(receive);

            }
            catch (Exception)
            {

                throw;
            }
            return Result;
        }

        public DataSet GetCurdPackedDetailsbyId(int Id)
        {
            dacurddata = new DACurdPackedData();
            return dacurddata.GetCurdPackedDetailsbyId(Id);
        }

        public DataSet GetCurdPackedDetails()
        {
            dacurddata = new DACurdPackedData();
            return dacurddata.GetCurdPackedDetails();
        }
    }
}