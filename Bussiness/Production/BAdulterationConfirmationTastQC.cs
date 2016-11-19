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
    public class BAdulterationConfirmationTastQC
    {
        DAAdulterationConfirmationTastQC daactqc;
        DataSet DS;

        public int adulterationqcdata(MAdulterationConfirmationTastQC receive )
        {
            daactqc = new DAAdulterationConfirmationTastQC();
            int Result = 0;
            try
            {

                Result = daactqc.adulterationqcdata(receive);

            }
            catch (Exception)
            {
                throw;
            }
            return Result;
        }

        public DataSet GetAdulterationConfirmationTastQCDetailsById(int Id)
        {
            daactqc = new DAAdulterationConfirmationTastQC();
            return daactqc.GetAdulterationConfirmationTastQCDetailsById(Id);
        }

        public DataSet GetAdulterationConfirmationTastQCDetails()
        {
            daactqc = new DAAdulterationConfirmationTastQC();
            return daactqc.GetAdulterationConfirmationTastQCDetails();
        }
    }
}