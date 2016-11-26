using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAcess;
using DataAccess.Production;
using Model.Production;
using System.Data;
using Model;
using Bussiness;

namespace Bussiness.Production
{
    public class BEffluentTreatmentPlant
    {
        DAEffluentTreatmentPlant daftp;
        DataSet DS;

        public int effluntplantdata(MEffluentTreatmentPlant receive)
        {
            daftp = new DAEffluentTreatmentPlant();
             int Result = 0;
        try
        {
            Result = daftp.effluntplantdata(receive);
        }
        catch (Exception)
        {
            throw;
        }
        return Result;
        }

        public DataSet GetEffluentTreatmentPlantDetailsById(int Id)
        {
            daftp = new DAEffluentTreatmentPlant();
            return daftp.GetEffluentTreatmentPlantDetailsById(Id);
        }

        public DataSet GetEffluentTreatmentPlantDetails()
        {
            daftp = new DAEffluentTreatmentPlant();
            return daftp.GetEffluentTreatmentPlantDetails();
        }
    }
}