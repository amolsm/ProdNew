using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DataAccess;
using DataAccess.Production;
using Bussiness;
using Model;
using Model.Production;

namespace Bussiness.Production
{
    public class BButterMilkPreparation
    {
        DAButterMilkPreparation dabmp;
        DataSet DS;

        public int buttermilkdata(MButterMilkPreparation receive)
        {
            dabmp = new DAButterMilkPreparation();
            int Result = 0;
            try
            {

                Result = dabmp.buttermilkdata(receive);

            }
            catch (Exception)
            {
                throw;
            }
            return Result;
        }

        public DataSet GetButterMilkDetailsById(int Id)
        {
            dabmp = new DAButterMilkPreparation();
            return dabmp.GetButterMilkDetailsById(Id);
        }

        public DataSet GetButterMilkDetails()
        {
            dabmp = new DAButterMilkPreparation();
            return dabmp.GetButterMilkDetails();
        }
    }
}