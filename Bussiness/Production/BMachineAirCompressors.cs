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
    public class BMachineAirCompressors
    {
        DAMachineAirCompressors damac;
        DataSet DS;

        public int machineairdata(MMachineAirCompressors receive)
        {
            damac = new DAMachineAirCompressors();
            int Result = 0;
            try
            {
                Result = damac.machineairdata(receive);
            }
            catch (Exception)
            {
                throw;
            }
            return Result;
        }

        public DataSet GetMachineAirCompressorsDetailsById(int Id)
        {
            damac = new DAMachineAirCompressors();
            return damac.GetMachineAirCompressorsDetailsById(Id);
        }

        public DataSet GetMachineAirCompressorsDetails()
        {
            damac = new DAMachineAirCompressors();
            return damac.GetMachineAirCompressorsDetails();
        }
    }
}