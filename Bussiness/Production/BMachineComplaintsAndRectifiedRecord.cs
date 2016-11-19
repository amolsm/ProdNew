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
    public class BMachineComplaintsAndRectifiedRecord
    {
        DAMachineComplaintsAndRectifiedRecord damcr;
        DataSet DS;

        public int machinereportdata(MMachineComplaintsAndRectifiedRecord receive)
        {
            damcr = new DAMachineComplaintsAndRectifiedRecord();
            int Result = 0;
            try
            {

                Result = damcr.machinereportdata(receive);

            }
            catch (Exception)
            {
                throw;
            }
            return Result;
        }

        public DataSet GetMachineComplaintsAndRectifiedDetailsById(int Id)
        {
            damcr= new DAMachineComplaintsAndRectifiedRecord();
            return damcr.GetMachineComplaintsAndRectifiedDetailsById(Id);
        }

        public DataSet GetMachineComplaintsAndRectifiedDetails()
        {
            damcr = new DAMachineComplaintsAndRectifiedRecord();
            return damcr.GetMachineComplaintsAndRectifiedDetails();
        }
    }

}