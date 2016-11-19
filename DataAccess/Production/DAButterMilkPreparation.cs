using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Production;
using DataAcess;
using System.Data;

namespace DataAccess.Production
{
    public class DAButterMilkPreparation
    {
        DBHelper _DBHelper = new DBHelper();
        DataSet DS;

        public int buttermilkdata(MButterMilkPreparation receive)
        {
            int result = 0;
            try
            { 
             DBParameterCollection paramcollection = new DBParameterCollection();
                paramcollection.Add(new DBParameter("@RMRId", receive.RMRId));
                paramcollection.Add(new DBParameter("@ButterMilkPreparationId", receive.ButterMilkPreparationId));
                paramcollection.Add(new DBParameter("@ButterMilkPreparationDate", receive.ButterMilkPreparationDate));
                paramcollection.Add(new DBParameter("@ButterMilkPreparationShiftId", receive.ButterMilkPreparationShiftId));
                paramcollection.Add(new DBParameter("@CurdQuantity", receive.CurdQuantity));
                paramcollection.Add(new DBParameter("@GingerQuantity", receive.GingerQuantity));
                paramcollection.Add(new DBParameter("@ChillyQuantity", receive.ChillyQuantity));
                paramcollection.Add(new DBParameter("@Salt", receive.Salt));
                paramcollection.Add(new DBParameter("@CurryLeaves", receive.CurryLeaves));
                paramcollection.Add(new DBParameter("@CorianderLeaves", receive.CorianderLeaves));
                paramcollection.Add(new DBParameter("@Lemon", receive.Lemon));
                paramcollection.Add(new DBParameter("@TotalPouchProduction", receive.TotalPouchProduction));
                paramcollection.Add(new DBParameter("@Damage", receive.Damage));
                paramcollection.Add(new DBParameter("@MixedAndTastedBy", receive.MixedAndTastedBy));
                paramcollection.Add(new DBParameter("@TastedAndMonitoredBy", receive.TastedAndMonitoredBy));
                paramcollection.Add(new DBParameter("@flag", receive.flag));
                result = _DBHelper.ExecuteNonQuery("sp_prod_ButterMilkPreparationDetails", paramcollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                String MSG = EX.ToString();
            }
            return result;
            }

        public DataSet GetButterMilkDetailsById(int RMRId)
        {
            DataSet DS = new DataSet();
            try
            {
                DBParameterCollection paramCollection = new DBParameterCollection();
                paramCollection.Add(new DBParameter("@RMRId", RMRId));
                DS = _DBHelper.ExecuteDataSet("sp_prod_GetButterMilkPreparationDetailsById", paramCollection, CommandType.StoredProcedure);
            }
            catch (Exception EX)
            {
                string MSG = EX.ToString();
            }

            return DS;
        }

        public DataSet GetButterMilkDetails()
        {
            DBParameterCollection paramCollection = new DBParameterCollection();
            return _DBHelper.ExecuteDataSet("sp_prod_GetButterMilkPreparationDetails", paramCollection, CommandType.StoredProcedure);
        }
      }
  }
