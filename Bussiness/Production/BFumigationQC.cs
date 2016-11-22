using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bussiness;
using DataAccess.Production;
using DataAcess;
using Model.Production;
using Model;
using System.Data;


namespace Bussiness.Production
{
    public class BFumigationQC
    {
        DAFumigationQC dafqc;
        DataSet DS;

        public int FumigationQCdata(MFumigationQC receive)
        {
            dafqc = new DAFumigationQC();
            int Result = 0;
            try
            {
                Result = dafqc.FumigationQCdata(receive);
            }
            catch (Exception)
            {

                throw;
            }
            return Result;
        }

        public DataSet GetFumigationQCDetailsById(int Id)
        {
            dafqc = new DAFumigationQC();
            return dafqc.GetFumigationQCDetailsById(Id);
        }

        public DataSet GetFumigationQCDetails(string dates)
        {

            dafqc = new DAFumigationQC();
            
            return dafqc.GetFumigationQCDetails(dates);
        }
    }
}