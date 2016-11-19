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
    public class BGheeProductionRegister
    {
        DAGheeProductionRegister dagpr;
        DataSet DS;

        public int gheedata(MGheeProductionRegister receive)
        {
            dagpr = new DAGheeProductionRegister();
            int Result = 0;
            try
            {
                Result = dagpr.gheedata(receive);
            }
            catch (Exception )
            {
                throw;
            }
            return Result;
        }

        public DataSet GetGheeProductionRegisterDetailsById(int Id)
        {
            dagpr = new DAGheeProductionRegister();
            return dagpr.GetGheeProductionRegisterDetailsById(Id);
        }

        public DataSet GetGheeProductionRegisterDetails()
        {
            dagpr = new DAGheeProductionRegister();
            return dagpr.GetGheeProductionRegisterDetails();
        }
    }
}