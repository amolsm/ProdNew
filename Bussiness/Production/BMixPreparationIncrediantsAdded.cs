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
    public class BMixPreparationIncrediantsAdded
    {
        DAMixPreparationIncrediantsAdded dampia;
        DataSet DS;

        public int mixpreparationdata(MMixPreparationIncrediantsAdded receive)
        {
            dampia = new DAMixPreparationIncrediantsAdded();
            int Result = 0;
            try
            {
                Result = dampia.mixpreparationdata(receive);
            }
            catch (Exception)
            {

                throw;
            }
             return   Result;
        }

        public DataSet GetMixPreparationIncrediantsAddedDetailsById(int Id)
        {
            dampia = new DAMixPreparationIncrediantsAdded();
            return dampia.GetMixPreparationIncrediantsAddedDetailsById(Id);
        }

        public DataSet GetMixPreparationIncrediantsAddedDetails()
      {
          dampia = new DAMixPreparationIncrediantsAdded();
          return dampia.GetMixPreparationIncrediantsAddedDetails();
      }
    }
}