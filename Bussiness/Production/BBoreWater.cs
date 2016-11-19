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
    public class BBoreWater
    {
        DABoreWater dabw;
        DataSet DS;

        public int borewaterdata(MBoreWater receive)
        { 
        dabw=new DABoreWater();
        int Result = 0;
        try
        {
            Result = dabw.borewaterdata(receive);
        }
        catch (Exception)
        {
            throw;
        }
        return Result;
        }

        public DataSet GetBoreWaterDetailsById(int Id)
        {
            dabw = new DABoreWater();
            return  dabw.GetBoreWaterDetailsById(Id);
        }

        public DataSet GetBoreWaterDetails()
        {
            dabw = new DABoreWater();
            return dabw.GetBoreWaterDetails();
        }
    }
}