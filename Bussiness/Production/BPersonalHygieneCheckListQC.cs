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
    public class BPersonalHygieneCheckListQC
    {
        DAPersonalHygieneCheckListQC daphcqc;
        DataSet DS;

        public int personalhygieneqcdata(MPersonalHygieneCheckListQC receive)
        {
            daphcqc = new DAPersonalHygieneCheckListQC();
            int Result = 0;
            try
            {
                Result = daphcqc.personalhygieneqcdata(receive);

            }

            catch (Exception)
            {
                throw;
            }
            return Result;
        }

        public DataSet GetPersonalHygieneCheckListQCDetailsById(int Id)
        {
            daphcqc = new DAPersonalHygieneCheckListQC();
            return daphcqc.GetPersonalHygieneCheckListQCDetailsById(Id);
        }

        public DataSet GetPersonalHygieneCheckListQCDetails()
        {
            daphcqc = new DAPersonalHygieneCheckListQC();
            return daphcqc.GetPersonalHygieneCheckListQCDetails();
        }
    }
}