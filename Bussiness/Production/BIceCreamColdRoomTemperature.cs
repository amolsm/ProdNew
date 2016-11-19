using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using System.Data;
using DataAcess;
using Bussiness;
using Model;
using DataAccess.Production;


namespace Bussiness.Production
{
    public class BIceCreamColdRoomTemperature
    {
        DAIceCreamColdRoomTemperature daict;
        DataSet DS;

        public int icecreamdata(MIceCreamColdRoomTemperature receive)
        {
            daict = new DAIceCreamColdRoomTemperature();
            int Result = 0;
            try
            {
                Result = daict.icecreamdata(receive);
            }
            catch (Exception )
            {
                throw;
            }
            return Result;
        }

        public DataSet GetIceCreamColdRoomTemperatureDetailsById(int Id)
        {
            daict = new DAIceCreamColdRoomTemperature();
            return daict.GetIceCreamColdRoomTemperatureDetailsById(Id);
        }

        public DataSet GetIceCreamColdRoomTemperatureDetails()
        {
            daict = new DAIceCreamColdRoomTemperature();
            return daict.GetIceCreamColdRoomTemperatureDetails();
        }
    }
}