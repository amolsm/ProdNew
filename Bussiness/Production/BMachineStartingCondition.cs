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
    public class BMachineStartingCondition
    {
        DAMachineStartingCondition damachine;
        DataSet DS;

        public int machinedata(MMachineStartingCondition receive)
        {
            damachine = new DAMachineStartingCondition();
            int Result = 0;
            try
            {

                Result = damachine.machinedata(receive);

            }
            catch (Exception)
            {
                throw;
            }
            return Result;
        }

        public DataSet GetMachineStartingConditionDetailsById(int Id)
        {
            damachine = new DAMachineStartingCondition();
            return damachine.GetMachineStartingConditionDetailsById(Id);
        }

        public DataSet GetMachineStartingConditionDetails()
        {
            damachine = new DAMachineStartingCondition();
            return damachine.GetMachineStartingConditionDetails();
        }

    }
}