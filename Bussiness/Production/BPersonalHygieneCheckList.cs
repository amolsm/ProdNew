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
    public class BPersonalHygieneCheckList
    {
        DAPersonalHygieneCheckList daphl;
        DataSet DS;

        public int personalhygienedata(MPersonalHygieneCheckList receive)
        {
            daphl = new DAPersonalHygieneCheckList();
            int Result = 0;
            try
            {
                Result = daphl.personalhygienedata(receive);
            }
            catch (Exception )
            {
            throw;
            }
            return Result;
        }

        public DataSet GetPersonalHygieneCheckListDetailsById(int Id)
        {
            daphl = new DAPersonalHygieneCheckList();
            return daphl.GetPersonalHygieneCheckListDetailsById(Id);
        }

        public DataSet GetPersonalHygieneCheckListDetails()
        {
            daphl = new DAPersonalHygieneCheckList();
            return daphl.GetPersonalHygieneCheckListDetails();
        }
    }
}