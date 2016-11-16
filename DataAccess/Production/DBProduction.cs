using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;


using System.Data;

namespace DataAccess.Production
{
    public class DBProduction
    {

        DBHelper _DBHelper = new DBHelper();
        DataSet DS;
        public int RMRData(RMRecieve receive)
        {
            int result = 0;
            try
                    
            {

                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@id", receive.RMRId));
                paramCollection.Add(new DBParameter("@RMRShiftId", receive.RMRShiftId));
                paramCollection.Add(new DBParameter("@RMRDate", receive.RMRDate));
                paramCollection.Add(new DBParameter("@TankMilkReciptNo", receive.TankMilkReciptNo));
                paramCollection.Add(new DBParameter("@TankerNo", receive.TankerNo));
                paramCollection.Add(new DBParameter("@TypeOfMilk", receive.MilkType));
                paramCollection.Add(new DBParameter("@Qty", receive.Quantity));
                paramCollection.Add(new DBParameter("@CreatedBy", receive.CreatedBy));
                paramCollection.Add(new DBParameter("@CreatedDate", receive.CreatedDate));
                paramCollection.Add(new DBParameter("@RMRQCStatus", receive.QCId));
                paramCollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("spProd_RMReceived", paramCollection, CommandType.StoredProcedure);

            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();


            }
            return result;
        }
        public DataSet GetRMRDetailsbyID(int Id)
        {
            DataSet DS = new DataSet();
            try
            {


                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@Id", Id));
                DS = _DBHelper.ExecuteDataSet("sp_GetRMRDetailsbyID", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception)
            {

            }
            return DS;
        }

        public DataSet GetRMRDetails()
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("sp_GetRMRInformation", paramCollection, CommandType.StoredProcedure);
        }

        public DataSet GetQualityDetails()
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("sp_GetRMRInformation", paramCollection, CommandType.StoredProcedure);
        }

    }
}