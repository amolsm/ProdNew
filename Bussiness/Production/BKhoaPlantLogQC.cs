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
    public class BKhoaPlantLogQC
    {
        DAKhoaPlantLogQC dakplqc;
        DataSet DS;

        public int khoadata(MKhoaPlantLogQC receive)
        {
            dakplqc = new DAKhoaPlantLogQC();
            int Result = 0;
            try
            {

                Result = dakplqc.khoadata(receive);

            }
            catch (Exception)
            {
                throw;
            }
            return Result;
        }

        public DataSet GetKhoaPlantlogQCDetailsById(int Id)
        {
            dakplqc = new DAKhoaPlantLogQC();
            return dakplqc.GetKhoaPlantlogQCDetailsById(Id);
        }

        public DataSet GetKhoaPlantlogQCDetails()
        {
            dakplqc = new DAKhoaPlantLogQC();
            return dakplqc.GetKhoaPlantlogQCDetails();
        }
    }
}